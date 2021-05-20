using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Other_Farmland : Item
{

    public Item_Other_Farmland()
    {
        itemName = "Farmland";
        stackSize = 1;
        itemDescription = "Can be placed. Allows for crops to be planted.";
        itemType = ItemType.Other;
        sprite = Icons.GetIcon(7);
        creditValue = 0;
    }
}
