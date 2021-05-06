using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{

    public List<InventoryElement> inventoryElements;

    public InventoryManager invManager;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach(Item item in invManager.items)
        {
            inventoryElements[i].item = item;
            i++;
        }
    }
}
