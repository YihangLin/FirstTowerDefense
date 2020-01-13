using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	public GameObject pause_ui;

	void Update()
	{
		/* show pause menu if ESC is pressed */
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	/*
	 * Name:		Pause
	 * Purpose:		Show pause menu, and stop time, so turrets stop firing and enemies stop moving
	 * Arguments:	none
	 */
	public void Pause()
	{
		pause_ui.SetActive (!pause_ui.activeSelf);

		if (pause_ui.activeSelf) 
		{
			Time.timeScale = 0f;//stop time

		} else {
			Time.timeScale = 1f;//resume
		}
	}

	/*
	 * Name:		Retry
	 * Purpose:		Load main scene to start again, and reset the number of enemies alive to 0
	 * Arguments:	none
	 */
	public void Retry()
	{
		Time.timeScale = 1f;
		WaveSpawner.numberEnemies = 0;
		SceneManager.LoadScene("Main");//reload scene
	}

	/*
	 * Name:		Menu
	 * Purpose:		load menu scene, and reset the number of enemies alive to 0
	 * Arguments:	none
	 */
	public void Menu()
	{
		Time.timeScale = 1f;
		WaveSpawner.numberEnemies = 0;
		SceneManager.LoadScene ("Menu");
	}
}
