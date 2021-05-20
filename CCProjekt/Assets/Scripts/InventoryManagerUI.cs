using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{

    public List<InventoryElementUI> inventoryElements;
    public List<InventoryElementUI> cropsElements;
    public InventoryManager invManager;

    public InventoryElementUI selectedElement;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach(InventoryElementUI inventoryElement in inventoryElements)
        {
            while (i < invManager.items.Count && invManager.items[i].itemType == Item.ItemType.Crop)
            {
                i++;
            }
            if (i < invManager.items.Count)
            {

                inventoryElement.item = invManager.items[i];
            }
            else
            { 
                inventoryElement.item = null;
            }
            i++;
        }
        i = 0;
        foreach (InventoryElementUI cropsElement in cropsElements)
        {
            while (i < invManager.items.Count && invManager.items[i].itemType != Item.ItemType.Crop)
            {
                i++;
            }
            if (i < invManager.items.Count)
            {

                cropsElement.item = invManager.items[i];
            }
            else
            {
                cropsElement.item = null;
            }
            i++;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            selectedElement = null;
        }
    }
}
