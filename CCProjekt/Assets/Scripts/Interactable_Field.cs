using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Field : Interactable
{
    public List<CropsScript> crops;
    public List<GameObject> cropPrefabs;
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
                    PlantField(0);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Carrot seed":
                    PlantField(1);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Wheat seed":
                    PlantField(2);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Melon seed":
                    PlantField(3);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Turnip seed":
                    PlantField(4);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                case "Pumpkin seed":
                    PlantField(5);
                    selectedItem.attachedInventory.RemoveItem(selectedItem.itemName, 1);
                    break;
                default:
                    print(selectedItem.itemName + " cannot be planted");
                    isEnabled = true;
                    break;

            }
        }
    }

    private void PlantField(int i)
    {
        GameObject go = Instantiate(cropPrefabs[i], transform.position, transform.rotation,transform);
        go.GetComponent<Interactable_Crop>().field = this;
    }
}
