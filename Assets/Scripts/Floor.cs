using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Floor : MonoBehaviour 
{

	public Color selected_floor;
	public Vector3 posi;

	public GameObject turret;
	public Turrets _turret;
	public bool isUpgraded = false;


	TurretBuild turretBuild;

	private Color floor_color;
	private Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		floor_color = rend.material.color;

		turretBuild = TurretBuild.ins;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + posi;
	}

	/*
	 * Name:		OnMouseEnter
	 * Purpose:		hover effects if players move mouse over floors
	 * Arguments:	none
	 */
	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (!turretBuild.buildAllowed) 
		{
			return;
		}
		rend.material.color = selected_floor;
	}

	void OnMouseExit()
	{
		rend.material.color = floor_color;
	}


	/*
	 * Name:		OnMouseDown
	 * Purpose:		if a turret is built on the floor, or environment objects are placed on the floor, then
	 * 				players can not build turret on this floor
	 * Arguments:	none
	 */
	void OnMouseDown()
	{
		/* check if player clicks on UI */
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
		/* player can't build the tower, if there are environment elements on the floor */
		if (gameObject.CompareTag ("envi"))
			return;

		/* if a turret is built on selected floor, set the floor as target */
		if (turret != null) 
		{
			turretBuild.setFloor (this);
			return;
		}

		if (!turretBuild.buildAllowed) 
		{
			return;
		}

		// check if player has enough money to build
		if (Currency.Money < turretBuild.getTurret().cost) 
		{ 
			return;
		}

		Currency.Money = Currency.Money - turretBuild.getTurret().cost;

		/* build the turret */
		GameObject tur = (GameObject)Instantiate (turretBuild.getTurret().prefab, GetBuildPosition(), Quaternion.identity);
		turret = tur;

		_turret = turretBuild.getTurret();

		/* add a build effect */
		GameObject beffect = (GameObject)Instantiate (turretBuild.BuildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy (beffect, 5f);
	}
		

	/*
	 * Name:		upgradeTurret
	 * Purpose:		destroy the current turret and build an upgraded version of current turret.
	 * Arguments:	none
	 */
	public void upgradeTurret()
	{
		if (isUpgraded == false) 
		{
			/* check if player has enough money to build */
			if (Currency.Money < _turret.upgradeCost) 
			{ 
				return;
			}

			Currency.Money = Currency.Money - _turret.upgradeCost;

			Destroy (turret);// destroy the old turret

			//biuld the upgraded one
			GameObject tur = (GameObject)Instantiate (_turret.upgradedPrefab, GetBuildPosition (), Quaternion.identity);
			turret = tur;

			GameObject beffect = (GameObject)Instantiate (turretBuild.BuildEffect, GetBuildPosition (), Quaternion.identity);
			Destroy (beffect, 5f);

			isUpgraded = true;
		}
	}

	/*
	 * Name:		sellTurret
	 * Purpose:		sell the turret and gain half of the cost
	 * Arguments:	none
	 */
	public void sellTurret()
	{
		Currency.Money += _turret.cost / 2;
		GameObject seffect = (GameObject)Instantiate (turretBuild.SellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy (seffect, 5f);
		Destroy (turret);
		_turret = null;
	}
}
