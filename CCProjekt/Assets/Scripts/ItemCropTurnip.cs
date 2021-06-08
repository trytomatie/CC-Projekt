using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropTurnip : Item
{

    public ItemCropTurnip()
    {
        itemName = "Turnip";
        stackSize = 1;
        itemDescription = "Turnip";
        itemType = ItemType.Crop;
        sprite = Icons.GetIcon(4);
        creditValue = 120;
    }
}
