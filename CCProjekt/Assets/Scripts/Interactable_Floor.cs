using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Floor : Interactable
{
    public GameObject fencePrefab;
    public GameObject farmlandPrefab;
    private void Start()
    {
        interactableText = "Place";
    }
    /// <summary>
    /// Place placable Items on the ground
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        // Get Selected Item
        Item selectedItem = interactor.GetComponent<InventoryManagerUI>().selectedElement.item;
        MouseRaycasterUI mouseRaycaster = interactor.GetComponent<MouseRaycasterUI>();
        // Get the rounded Impact point of the MouseRaycaster
        Vector3 spawnPoint = mouseRaycaster.roundedImpactPoint;
        // Place Item depending on Item-name
        switch(selectedItem.itemName)
        {
            case "Fence":
                Instantiate(fencePrefab, spawnPoint, mouseRaycaster.fenceIndicator.transform.rotation);
                break;
            case "Farmland":
                Instantiate(farmlandPrefab, spawnPoint, mouseRaycaster.farmlandIndicator.transform.rotation);
                break;
        }

        // Remove Item or Item stack from inventory
        selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
    }
}
