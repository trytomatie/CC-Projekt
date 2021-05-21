using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycasterUI : MonoBehaviour
{
    public GameObject indicator;
    public GameObject fenceIndicator;
    public GameObject farmlandIndicator;

    public GameObject target = null;
    private InventoryManagerUI inventoryManagerUI;
    public int[] test = new int[2];

    private Vector3 lastMousePos;
    public Vector3 lastRaycastImpactPoint;
    public Vector3 roundedImpactPoint;

    private GameObject currentObjectIndicator;
    // Start is called before the first frame update
    void Start()
    {
        currentObjectIndicator = fenceIndicator;
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
            fenceIndicator.transform.position = new Vector3(0, -100, 0);
            if (inventoryManagerUI.selectedElement.item.stackSize == 0)
            {
                inventoryManagerUI.selectedElement = null;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentObjectIndicator.transform.Rotate(new Vector3(0, 90, 0));

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentObjectIndicator.transform.Rotate(new Vector3(0, -90, 0));
        }
    }

    /// <summary>
    /// Raycasts to gameworld for game interaction
    /// - By Chrsitan Scherzer
    /// </summary>
    private void Raycast()
    {
        if (lastMousePos != Input.mousePosition || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            target = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.SphereCastAll(ray, 0.05f);
            foreach (RaycastHit hit in hits)
            {
                if(inventoryManagerUI.selectedElement != null && inventoryManagerUI.selectedElement.item != null)
                {
                    lastRaycastImpactPoint = hit.point;
                    roundedImpactPoint = new Vector3(Mathf.Round(hit.point.x *2), hit.point.y *2, Mathf.Round(hit.point.z * 2)) / 2;
                    if (inventoryManagerUI.selectedElement.item.itemType == Item.ItemType.Seed)
                    { 
                        if (hit.collider.CompareTag("Field") && hit.collider.GetComponent<Interactable_Field>().isEnabled)
                        {
                            indicator.transform.position = hit.collider.gameObject.transform.position;
                            lastMousePos = Input.mousePosition;
                            target = hit.collider.gameObject;
                            return;
                        }
                    }
                    if (inventoryManagerUI.selectedElement.item.itemType == Item.ItemType.Other)
                    {
                        if(hit.collider.CompareTag("Floor"))
                        {
                            
                            switch(inventoryManagerUI.selectedElement.item.itemName)
                            {
                                case "Fence":
                                    currentObjectIndicator = fenceIndicator;
                                    break;
                                case "Farmland":
                                    currentObjectIndicator = farmlandIndicator;
                                    break;
                            }
                            currentObjectIndicator.transform.position = roundedImpactPoint;
                            lastMousePos = Input.mousePosition;
                            target = hit.collider.gameObject;
                            return;
                        }
                    }
                }
            }

            indicator.transform.position = new Vector3(0, -100, 0);
            fenceIndicator.transform.position = new Vector3(0, -100, 0);
            farmlandIndicator.transform.position = new Vector3(0, -100, 0);
        }
        lastMousePos = Input.mousePosition;
    }
}
