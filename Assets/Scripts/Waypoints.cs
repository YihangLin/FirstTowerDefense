using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour 
{
	public static Transform[] points;


	/*
	 * Name: 		Awake
	 * Purpose:		Load all the waypoints into an array
	 * Arguments:	none
	 */

	void Awake () 
	{
		points = new Transform[transform.childCount];

		for (int i = 0; i < points.Length; i++) 
		{
			points[i] = transform.GetChild (i);
		}
	}
	

}
