using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	public Wave[] enemyWaves;
	public Transform spawnPoint;

	public static int numberEnemies = 0;
	public float delay_time = 3f;
	private float countdown = 3f;
	public Text wavecd;
	private int waveIndex = 0;
	public Manager manager;

	// Update is called once per frame
	void Update () 
	{
		/* if enemies of current wave are not eliminated, return */
		if (numberEnemies > 0) 
		{
			return;
		}

		/* player survived all waves */
		if (waveIndex == enemyWaves.Length) 
		{
			manager.Win ();
			/* stop the script to stop spawning enemies */
			this.enabled = false;
		}

		/* spawn enemies */
		if (countdown <= 0f) 
		{
			StartCoroutine(SpawnWave ());
			countdown = delay_time;
			return;
		}
			
		countdown -= Time.deltaTime;
		wavecd.text = "Next Wave: " + string.Format ("{0:0}", countdown);

	}


	/*
	 * Name:		SpawnWave
	 * Purpose:		use coroutine to spawn enemies for current wave
	 * Arguments:	none
	 */
	IEnumerator SpawnWave()
	{
		Wave currentWave = enemyWaves[waveIndex];

		numberEnemies = currentWave.numofEnemy;

		for (int i = 0; i < currentWave.numofEnemy; i++) 
		{
			/* spawn an enemy */
			Instantiate (currentWave.enemy, spawnPoint.position, spawnPoint.rotation);
			/* wait for half second to spawn next enemy*/
			yield return new WaitForSeconds (0.5f);
		}
		waveIndex++;


	}
}
