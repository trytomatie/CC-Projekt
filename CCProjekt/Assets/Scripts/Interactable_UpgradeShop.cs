using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_UpgradeShop : Interactable
{
    public GameObject upgradeUI;
    private void Start()
    {

    }
    /// <summary>
    /// Open Upgrade Ui
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        Time.timeScale = 0;
        upgradeUI.SetActive(true);
    }
}
