using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Field : Interactable
{
    public List<CropsScript> crops;

    private void Start()
    {
        interactableText = "Plant";
    }
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
                    break;
                case "Carrot seed":
                    crops[1].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Wheat seed":
                    crops[2].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Melon seed":
                    crops[3].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Turnip seed":
                    crops[4].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Pumpkin seed":
                    crops[5].PlantCrop();
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                default:
                    print(selectedItem.itemName + " cannot be planted");
                    isEnabled = true;
                    break;

            }
        }
    }
}
