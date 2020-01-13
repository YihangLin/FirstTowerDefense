using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Name:		Shop
 * Purpose:		set functions for turret menu
 * Arguments:	none
 */
public class Shop : MonoBehaviour 
{
	TurretBuild turretBuild;
	public Turrets turreta;
	public Turrets missile;
	public Turrets lazer;
	public Turrets ice;

	void Start()
	{
		turretBuild = TurretBuild.ins;
	}
		
	public void BuyTurretA()
	{
		turretBuild.setTurret (turreta);
	}
	public void BuyMissile()
	{
		turretBuild.setTurret (missile);
	}
	public void BuyLaser()
	{
		turretBuild.setTurret (lazer);
	}
	public void BuyIce()
	{
		turretBuild.setTurret (ice);
	}
		
}
