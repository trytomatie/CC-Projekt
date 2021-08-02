using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryElementUI : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    public Item item;
    public Image image;
    public TextMeshProUGUI stackText;

    private InventoryManagerUI inventoryManagerUI;

    private void Start()
    {
        inventoryManagerUI = GameObject.FindObjectOfType<InventoryManagerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item == null || item.stackSize <= 0)
        {
            item = null;
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
        stackText.text = "x" + item.stackSize;
    }

    public void SelectElement()
    {
        inventoryManagerUI.selectedElement = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryManagerUI.HoveredItem = item;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryManagerUI.HoveredItem = null;
        
    }
}
