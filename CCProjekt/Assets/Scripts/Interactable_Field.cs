using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Field : Interactable
{
    public List<CropsScript> crops;

    public override void Interact(GameObject interactor)
    {
        Item selectedItem = interactor.GetComponent<InventoryManagerUI>().selectedElement.item;
        if(selectedItem != null)
        {
            isEnabled = false;
            switch (selectedItem.itemName)
            {
                case "Corn seed":
                    crops[0].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    print("Plant Corn seed");
                    break;
                case "Carrot seed":
                    crops[1].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    print("Carrot Corn seed");
                    break;
                default:
                    print(selectedItem.itemName + " cannot be planted");
                    isEnabled = true;
                    break;

            }
        }
    }
}