using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour 
{
	private Floor target;
	public GameObject ui;
	public Text upgradeCost;
	public Button upgradeButton;
	public Text sellAmount;


	/*
	 * Name:		setTarget
	 * Purpose:		show upgrade UI, if player clicked built turrets
	 * Arguments:	Floor
	 */
	public void setTarget (Floor tar)
	{
		target = tar;

		transform.position = target.GetBuildPosition ();

		if (!target.isUpgraded) 
		{
			upgradeCost.text = "$" + target._turret.upgradeCost;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "Upgraded";
		}

		sellAmount.text = "$" + target._turret.cost / 2;
		ui.SetActive (true);
	}

	/*
	 * Name:		Hideui
	 * Purpose:		hide current ui
	 * Arguments:	none
	 */
	public void Hideui()
	{
		ui.SetActive (false);
	}
		
	public void Upgrade()
	{
		target.upgradeTurret ();
		TurretBuild.ins.unselectFloor();
	}

	public void Sell()
	{
		target.sellTurret ();
		TurretBuild.ins.unselectFloor ();
	}
}
