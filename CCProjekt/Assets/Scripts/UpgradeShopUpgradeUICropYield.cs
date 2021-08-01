using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeUICropYield : UpgradeShopUpgradeUI
{
    public float increase = 0.1f;
    public int cost = 100;


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
            GameManager.Instance.cropYieldMultipier += increase;
            GameManager.Instance.Credits -= cost;
            cost = Mathf.RoundToInt(cost * 1.2f);
            RefreshDescription();
        }
    }

    private void RefreshDescription()
    {
        var emission = player.bubbleParticles.emission;
        
        upgradeDescription = "Upgrades the amount of credits crops yield from <color=blue>" + (GameManager.Instance.cropYieldMultipier *100) + " %</color> to <color=blue>" + ((GameManager.Instance.cropYieldMultipier + increase) * 100) + " %</color>. \n" +
    "Cost: <color=blue>" + cost + "</color> credits";
        RefreshText();
    }
}
