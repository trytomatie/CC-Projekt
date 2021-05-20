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
    public override void Interact(GameObject interactor)
    {
        Item selectedItem = interactor.GetComponent<InventoryManagerUI>().selectedElement.item;
        MouseRaycasterUI mouseRaycaster = interactor.GetComponent<MouseRaycasterUI>();
        Vector3 spawnPoint = mouseRaycaster.roundedImpactPoint;
        switch(selectedItem.itemName)
        {
            case "Fence":
                Instantiate(fencePrefab, spawnPoint, mouseRaycaster.fenceIndicator.transform.rotation);
                break;
            case "Farmland":
                Instantiate(farmlandPrefab, spawnPoint, mouseRaycaster.farmlandIndicator.transform.rotation);
                break;
        }

        selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
    }
}
