using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Corn : Item
{

    public Item_CropSeed_Corn()
    {
        itemName = "Corn seed";
        stackSize = 1;
        itemDescription = "Corn seed";
        sprite = Icons.GetIcon(0);
    }
}
