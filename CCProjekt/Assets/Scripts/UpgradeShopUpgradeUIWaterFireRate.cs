using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeUIWaterFireRate : UpgradeShopUpgradeUI
{
    public float waterFireRateUpgrade = 1;
    public int cost = 50;

    public override void Initialize()
    {
        RefreshDescription();
    }

    /// <summary>
    /// Upgrades the Firerate
    /// By Christian Scherzer
    /// </summary>
    public void Upgrade()
    {
        if (GameManager.Instance.Credits >= cost)
        {
            var emission = player.bubbleParticles.emission;
            emission.rateOverTimeMultiplier += waterFireRateUpgrade;

            GameManager.Instance.Credits -= cost;
            cost = Mathf.RoundToInt(cost * 1.1f);
            RefreshDescription();
        }
    }

    /// <summary>
    /// Refreshes the Description
    /// By Christian Scherzer
    /// </summary>
    private void RefreshDescription()
    {
        var emission = player.bubbleParticles.emission;
        
        upgradeDescription = "Upgrades the firerate from your blaster from <color=blue>" + emission.rateOverTimeMultiplier + "</color> to <color=blue>" + (emission.rateOverTimeMultiplier + waterFireRateUpgrade) + "</color>. \n" +
    "Cost: <color=blue>" + cost + "</color> credits";
        RefreshText();
    }
}
