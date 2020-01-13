using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour 
{
	private Transform target;
	private Enemy targetEnemy;

	public float range = 10f;

	public int lazerDamage = 30;
	public ParticleSystem lazerEffect;
	public Light lazerLight;

	public float fire_rate = 1f;
	private float nextFire = 0f;

	public Transform fire_gun;
	public float turn_speed = 10f;

	public bool laser = false;
	public bool ice = false;
	private float iceSlow = .5f;
	public LineRenderer lazerLine;

	public GameObject bullet;
	public Transform bullet_spawn;

	public string enemyTag = "Enemy";

	// Update is called once per frame
	void Update () 
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag); 
		float shortest = Mathf.Infinity;

		GameObject nearest = null;
		/* get the closest enemy */
		foreach(GameObject enemy in enemies)
		{
			float distance = Vector3.Distance (transform.position, enemy.transform.position);

			if (distance < shortest) 
			{
				shortest = distance;
				nearest = enemy;
			}
		}

		if (nearest != null && shortest <= range) 
		{
			target = nearest.transform;
			targetEnemy = nearest.GetComponent<Enemy> ();
		}
		else		
		{
			target = null;
		}
				
		if (target == null) 
		{
			/* if it is a lazer turret, then enable lazer effect */
			if (laser) 
			{
				if (lazerLine.enabled) 
				{
					lazerLine.enabled = false;
					lazerEffect.Stop();
					lazerLight.enabled = false;
				}	
			}
			return;
		}

		/* get the vector direction, and rotates the turret, make the turret facing to closest enemy */
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		/* use lerp for smooth rotation */
		Vector3 rotation = Quaternion.Lerp(fire_gun.rotation, lookRotation, Time.deltaTime * turn_speed).eulerAngles;
		/* rotate arround y-axis */
		fire_gun.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		/* if it is a ice turret, then slows the enemies down */
		if (ice) 
		{
			targetEnemy.Slow (iceSlow);
		}

		/* lazer damage and lazer effect */
		if (laser) 
		{
			targetEnemy.DamageTaken (lazerDamage * Time.deltaTime);// lazer damage overtime

			if (lazerLine.enabled != true) 
			{
				lazerLine.enabled = true;
				lazerEffect.Play();
				lazerLight.enabled = true;
			}
			lazerLine.SetPosition (0, bullet_spawn.position);
			lazerLine.SetPosition (1, target.position);
		}
		else 
		{
			
			if(Time.time > nextFire) 
			{
				/* calculate fire rates */
				nextFire = Time.time + fire_rate;

				/* fire the bullets */
				GameObject bul = (GameObject)Instantiate (bullet, bullet_spawn.position, bullet_spawn.rotation);

				Bullet bullet_fired = bul.GetComponent<Bullet> ();

				if (bullet_fired != null) 
				{
					bullet_fired.SetTarget (target);
				}
			}

		}
		
	}

}
