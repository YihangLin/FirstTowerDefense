using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuild : MonoBehaviour 
{
	public GameObject BuildEffect;
	public GameObject SellEffect;

	private Turrets selectTurret;
	private Floor selectedFloor;
	public SelectUI sui;

	public static TurretBuild ins;

	void Awake()
	{
		ins = this;
	}

	public bool buildAllowed
	{ 
		get 
		{
			return selectTurret != null; 
		}
	}

	/*
	 * Name:		setFloor
	 * Purpose:		if there is a turret built on this floor, then set current selected turret to null
	 * 				and close hover effect on the floor. If player selects floor, the upgrade menu will
	 * 				not show up.
	 * Arguments:	Floor
	 */

	public void setFloor (Floor floor)
	{
		/* if player clicks on the selected floor, hide the upgrade UI */
		if (selectedFloor == floor) 
		{
			unselectFloor ();
			return;
		}
		selectedFloor = floor;
		selectTurret = null;

		sui.setTarget (floor);
	}

	/*
	 * Name:		setTurret
	 * Purpose:		if player selects a turret, then hide the upgrade's UI
	 * Arguments:	turret
	 */
	public void setTurret(Turrets turret)
	{
		selectTurret = turret;
		unselectFloor ();
	}

	public Turrets getTurret()
	{
		return selectTurret;
	}

	/*
	 * Name:		unselectFloor
	 * Purpose:		Hide the upgrade's UI
	 * Arguments:	none
	 */
	public void unselectFloor()
	{
		selectedFloor = null;
		sui.Hideui ();
	}
}
