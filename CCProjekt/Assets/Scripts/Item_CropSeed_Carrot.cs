using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_CropSeed_Carrot : Item
{

    public Item_CropSeed_Carrot()
    {
        itemName = "Carrot seed";
        stackSize = 1;
        itemDescription = "Carrot seed";
        sprite = Icons.GetIcon(1);
    }
}
