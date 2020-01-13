using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{

	public static bool gameover;

	public GameObject gameoverUI;
	public GameObject winUI;

	void Start()
	{
		gameover = false;
	}

	void Update () 
	{
		if (gameover)
			return;

		if (Currency.Lives <= 0) 
		{
			Gameover ();
		}
	}

	void Gameover()
	{
		gameover = true;
		gameoverUI.SetActive (true);//enable game over menu
	}

	public void Win()
	{
		gameover = true;//stop moving camera
		winUI.SetActive (true);
	}
}
