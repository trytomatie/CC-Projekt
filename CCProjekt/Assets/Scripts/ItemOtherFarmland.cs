using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOtherFarmland : Item
{

    public ItemOtherFarmland()
    {
        itemName = "Farmland";
        stackSize = 1;
        itemDescription = "Can be placed. Allows for crops to be planted.";
        itemType = ItemType.Other;
        sprite = Icons.GetIcon(7);
        creditValue = 100;
    }
}
