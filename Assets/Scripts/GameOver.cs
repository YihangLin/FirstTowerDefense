using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{

	// Use this for initialization

	public void Retry()
	{
		SceneManager.LoadScene("Main");
	}

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
