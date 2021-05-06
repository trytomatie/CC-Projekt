using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Field : Interactable
{
    public List<GameObject> crops;

    public override void Interact(GameObject interactor)
    {
        InventoryManager invManager = interactor.GetComponent<InventoryManager>();
        Item selectedItem = invManager.GetSelectedItem();
        if(selectedItem != null)
        {
            isEnabled = false;
            switch (selectedItem.itemName)
            {
                case "Corn seed":
                    crops[0].SetActive(true);
                    print("Plant Corn seed");
                    break;
                case "Carrot seed":
                    crops[1].SetActive(true);
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
