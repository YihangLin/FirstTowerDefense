using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name:		Bullet
 * Purpose:		move bullets objects
 * Arguments:	none
 */

public class Bullet : MonoBehaviour 
{

	private Transform target;
	public int damage = 50;

	public float bullet_speed = 50f;
	public float missile_Radius = 3f;

	public GameObject impactEffect;

	public void SetTarget(Transform bullet_target)
	{
		target = bullet_target;
	}

	// Update is called once per frame
	void Update () 
	{
		/* if enemy dies, destroy the bullet object*/
		if (target == null) 
		{
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distance = bullet_speed * Time.deltaTime;
		/* if the length of the direction vector less than distance to enemy
		 * then bullet has reached the target and deal some damage*/
		if (dir.magnitude <= distance) 
		{
			GameObject effects = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (effects, 3f);

			if (missile_Radius > 0f) 
			{
				/* missile has area damage */
				Collider[] collis = Physics.OverlapSphere (transform.position, missile_Radius);
				foreach (Collider colli in collis) 
				{
					if (colli.tag == "Enemy") 
					{
						Enemy ene = colli.transform.GetComponent<Enemy> ();
						if (ene != null) 
						{
							ene.DamageTaken (damage);
						}
					}
				}
			} 
			else 
			{
				Enemy e = target.GetComponent<Enemy> ();
				if (e != null) 
				{
					e.DamageTaken (damage);
				}
			}
			Destroy (gameObject);
			return;
		}

		transform.Translate (dir.normalized * distance, Space.World);
		transform.LookAt (target);
	}
}
