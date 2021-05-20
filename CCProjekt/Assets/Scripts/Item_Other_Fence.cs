using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Other_Fence : Item
{

    public Item_Other_Fence()
    {
        itemName = "Fence";
        stackSize = 1;
        itemDescription = "Can be placed to slow enemies by 70%";
        itemType = ItemType.Other;
        sprite = Icons.GetIcon(6);
        creditValue = 0;
    }
}
