using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Field : Interactable
{
    public List<CropsScript> crops;
    public List<GameObject> cropPrefabs;
    public AudioClip plantSound;
    private void Start()
    {
        interactableText = "Plant";
    }

    /// <summary>
    /// Plant crop
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        // Get selected Item
        Item selectedItem = interactor.GetComponent<InventoryManagerUI>().selectedElement.item;
        // Plant seed depending on item
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

    /// <summary>
    /// Plant seed
    /// By Christian Scherzer and Shaina Milde
    /// </summary>
    /// <param name="i"></param>
    private void PlantField(int i)
    {
        GameObject go = Instantiate(cropPrefabs[i], transform.position, transform.rotation,transform);
        go.GetComponent<Interactable_Crop>().field = this;
        GameManager.Instance.SpawnInterfaceSound(plantSound, 0.2f);
    }
}
