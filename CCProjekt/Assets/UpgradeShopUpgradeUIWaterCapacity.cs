using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeUIWaterCapacity : UpgradeShopUpgradeUI
{
    public int cost = 30;
    public int waterCappacityUpgrade = 20;


    public override void Initialize()
    {
        RefreshDescription();
    }
    /// <summary>
    /// Upgrades the watercappacity
    /// By Christian Scherzer
    /// </summary>
    public void Upgrade()
    {
        if (GameManager.Instance.Credits >= cost)
        {
            player.maxWater += waterCappacityUpgrade;
            player.Water = player.Water;
            GameManager.Instance.Credits -= cost;
            cost = Mathf.RoundToInt(cost * 1.2f);
            RefreshDescription();
        }

    }

    private void RefreshDescription()
    {
        upgradeDescription = "Upgrades the water capacity from <color=blue>" + player.maxWater + "</color> to <color=blue>" + (player.maxWater + waterCappacityUpgrade) + "</color>. \n" +
    "Cost: <color=blue>" + cost + "</color> credits";
        RefreshText();
    }
}
