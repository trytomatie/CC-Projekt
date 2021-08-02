using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{

    public List<InventoryElementUI> inventoryElements;
    public List<InventoryElementUI> cropsElements;
    public InventoryManager invManager;

    public GameObject itemDescription;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI itemDescriptionNameText;

    public InventoryElementUI selectedElement;

    private Item hoveredItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedElement = inventoryElements[0];
            hoveredItem = inventoryElements[0].item;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedElement = inventoryElements[1];
            hoveredItem = inventoryElements[1].item;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedElement = inventoryElements[2];
            hoveredItem = inventoryElements[2].item;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedElement = inventoryElements[3];
            hoveredItem = inventoryElements[3].item;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedElement = inventoryElements[4];
            hoveredItem = inventoryElements[4].item;
        }

        int i = 0;
        // Puts all Items that are not crops into the Inventory UI
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
        // Puts all crops into the crop ui
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

        // If the right mb is pressed , or the escape key is pressed, set selectedElement to null
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            selectedElement = null;
        }
    }

    public Item HoveredItem 
    { 
        get => hoveredItem;
        set {

            hoveredItem = value;
            if(hoveredItem == null)
            {
                itemDescription.SetActive(false);
            }
            else
            {
                itemDescription.SetActive(true);
                itemDescriptionNameText.text = hoveredItem.itemName;
                itemDescriptionText.text = hoveredItem.itemDescription;
            }
                
         }
    }
}
