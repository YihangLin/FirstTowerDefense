using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public float normalSpeed = 10f;
	public float speed;

	public float startHealth = 100;
	private float health;
	public int moneyGain = 50;

	public Image healthBar;

	public GameObject deathEffect;
	private Transform target;
	private int way = 0;

	private bool enemyDead = false;

	void Start () 
	{
		target = Waypoints.points [0];
		speed = normalSpeed;
		health = startHealth;
	}
		
	/*
	 * Name:		Slow
	 * Purpose:		slow the enemies down, only for ice tower
	 * Arguments:	float number
	 */
	public void Slow (float slowNum)
	{
		speed = normalSpeed * (1f - slowNum);// slow the enemy
	}

	void Update () 
	{
		//enemy moves to the location
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
		
		//enemy rotation, facing to the location
		Vector3 newDir = Vector3.RotateTowards (transform.forward, dir, speed * Time.deltaTime, 0.0F);
		transform.rotation = Quaternion.LookRotation (newDir);

		/* load next point, if enemy reaches the current point */
		if (Vector3.Distance (transform.position, target.position) <= 0.5f) 
		{
			/* enemy reaches the base */
			if (way >= Waypoints.points.Length - 1) 
			{
				Currency.Lives--;
				WaveSpawner.numberEnemies--;
				Destroy (gameObject);
				return;
			}

			way++;
			target = Waypoints.points [way];
		}
		speed = normalSpeed;
	}

	/*
	 * Name:		DamageTaken
	 * Purpose:		decrease the health of enemies, and destroy game object of enemies if they are dead.
	 * 				Players gain money by eliminating enemies.
	 * Arguments:	float number, damage caused by turrets
	 */
	public void DamageTaken (float amount)
	{

		health = health - amount;


		healthBar.fillAmount = health / startHealth; //show hp bar 

		if(health <= 0 && !enemyDead)
		{
			enemyDead = true;
			Currency.Money += moneyGain;
			/* create a death effect */
			GameObject eff = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
			Destroy (eff, 5f);
			Destroy(gameObject);

			WaveSpawner.numberEnemies--;
		}
	}

		
}
