using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{

    public Item item;

    public Image image;
    public TextMeshProUGUI stackText;

    // Update is called once per frame
    void Update()
    {
        if (item == null)
        {
            image.enabled = false;
            stackText.enabled = false;
            return;
        }
        else
        {
            image.enabled = true;
            stackText.enabled = true;
        }
        image.sprite = item.sprite;
        stackText.text = "x " + item.stackSize;

    }
}
