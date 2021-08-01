using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCropSeedTurnip : Item
{

    public ItemCropSeedTurnip()
    {
        itemName = "Turnip seed";
        stackSize = 1;
        itemDescription = "Can be used to plant Turnips.\nValue: 120 credits";
        itemType = ItemType.Seed;
        sprite = Icons.GetIcon(4);
    }
}
