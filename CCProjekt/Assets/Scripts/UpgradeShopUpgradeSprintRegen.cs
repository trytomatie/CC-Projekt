using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeSprintRegen : UpgradeShopUpgradeUI
{
    public int regenAmount = 1;
    public int cost = 50;

    public override void Initialize()
    {
        RefreshDescription();
    }

    /// <summary>
    /// Upgrades the firerate
    /// By Christian Scherzer
    /// </summary>
    public void Upgrade()
    {
        if (GameManager.Instance.Credits >= cost)
        {
            player.GetComponent<StatusManager>().staminaRegen += regenAmount;

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
        upgradeDescription = "Upgrades sprint regeneration from <color=blue>" + player.GetComponent<StatusManager>().staminaRegen + "</color> to <color=blue>" + (player.GetComponent<StatusManager>().staminaRegen + regenAmount) + "</color>. \n" +
    "Cost: <color=blue>" + cost + "</color> credits";
        RefreshText();
    }
}
