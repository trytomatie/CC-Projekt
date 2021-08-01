using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeSprintRegen : UpgradeShopUpgradeUI
{
    public int regenAmount = 3;
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
            var emission = player.GetComponent<StatusManager>().staminaRegen += regenAmount;

            GameManager.Instance.Credits -= cost;
            cost = Mathf.RoundToInt(cost * 1.2f);
            RefreshDescription();
        }
    }

    private void RefreshDescription()
    {
        var emission = player.bubbleParticles.emission;
        
        upgradeDescription = "Upgrades the firerate from your blaster from <color=blue>" + emission.rateOverTimeMultiplier + "</color> to <color=blue>" + (emission.rateOverTimeMultiplier + waterFireRateUpgrade) + "</color>. \n" +
    "Cost: <color=blue>" + cost + "</color> credits";
        RefreshText();
    }
}
