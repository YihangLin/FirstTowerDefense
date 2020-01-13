using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour 
{
	/*
	 * Name:		playAgain
	 * Purpose:		if the player selsects play again, then the game will load the main scene
	 * Arguments:	none
	 */
	public void playAgain()
	{
		SceneManager.LoadScene("Main");
	}

	/*
	 * Name:		Menu
	 * Purpose:		if the player selects Menu, then the game will load the menu scene
	 * Arguments:	none
	 */
	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
