using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Name:		CameraController
 * Purpose:		if players moves mouse to the edges of screen, then the camera moves to the edge
 * 				just like starcraft
 * Arguments:	none
 */
public class CameraController : MonoBehaviour 
{


	public float camSpeed = 30f;
	public float boardArea = 5f;
	public float scrollSpeed = 5f;
	public float min = 10f;
	public float max = 80f;

	void Update () 
	{
		if (Manager.gameover == true) 
		{
			//stop moving the camera while game is over
			this.enabled = false;
			return;
		}

		if (Input.mousePosition.y >= boardArea) 
		{ 
			//move mouse to the edge of the screen
			transform.Translate (Vector3.left * camSpeed * Time.deltaTime, Space.World);
		}

		if (Input.mousePosition.y <= Screen.height - boardArea) 
		{ 
			//move mouse to the edge of the screen
			transform.Translate (Vector3.right * camSpeed * Time.deltaTime, Space.World);
		}

		if (Input.mousePosition.x >= Screen.width - boardArea) 
		{ 
			//move mouse to the edge of the screen
			transform.Translate (Vector3.forward * camSpeed * Time.deltaTime, Space.World);
		}

		if (Input.mousePosition.x <= boardArea) 
		{ 
			//move mouse to the edge of the screen
			transform.Translate (Vector3.back * camSpeed * Time.deltaTime, Space.World);
		}

		Vector3 currentPos = transform.position;
		/* use scroll to zoom in or out */
		currentPos.y = currentPos.y - Input.GetAxis ("Mouse ScrollWheel") * 100 * scrollSpeed * Time.deltaTime; 
		currentPos.y = Mathf.Clamp (currentPos.y, min, max);
		transform.position = currentPos;

	}


}
