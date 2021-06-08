using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOtherFence : Item
{

    public ItemOtherFence()
    {
        itemName = "Fence";
        stackSize = 1;
        itemDescription = "Can be placed to slow enemies by 70%";
        itemType = ItemType.Other;
        sprite = Icons.GetIcon(6);
        creditValue = 80;
    }
}
