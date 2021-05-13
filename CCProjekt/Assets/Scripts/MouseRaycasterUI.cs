using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycasterUI : MonoBehaviour
{
    public GameObject indicator;


    public GameObject target = null;
    private InventoryManagerUI inventoryManagerUI;
    public int[] test = new int[2];

    private Vector3 lastMousePos;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManagerUI = GetComponent<InventoryManagerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        if(Input.GetMouseButtonDown(0) && target != null)
        {
            target.GetComponent<Interactable>().Interact(gameObject);
            indicator.transform.position = new Vector3(0, -100, 0);
            if (inventoryManagerUI.selectedElement.item.stackSize == 0)
            {
                inventoryManagerUI.selectedElement = null;
            }
        }
    }

    /// <summary>
    /// Raycasts to gameworld for game interaction
    /// - By Chrsitan Scherzer
    /// </summary>
    private void Raycast()
    {
        if (lastMousePos != Input.mousePosition)
        {
            target = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.SphereCastAll(ray, 0.05f);
            foreach (RaycastHit hit in hits)
            {
                if(inventoryManagerUI.selectedElement != null && inventoryManagerUI.selectedElement.item != null)
                { 
                    if (hit.collider.tag == "Field" 
                        && inventoryManagerUI.selectedElement.item.itemType == Item.ItemType.Seed 
                        && hit.collider.GetComponent<Interactable_Field>().isEnabled)
                    {
                        indicator.transform.position = hit.collider.gameObject.transform.position;
                        lastMousePos = Input.mousePosition;
                        target = hit.collider.gameObject;
                        return;
                    }
                }
            }
            indicator.transform.position = new Vector3(0, -100, 0);
        }
        lastMousePos = Input.mousePosition;
    }
}
