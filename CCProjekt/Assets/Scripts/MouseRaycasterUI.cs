using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRaycasterUI : MonoBehaviour
{
    public GameObject indicator;
    public GameObject fenceIndicator;
    public GameObject farmlandIndicator;
    public EventSystem eventSystem;
    public GameObject target = null;
    
    public int[] test = new int[2];

    public Vector3 lastRaycastImpactPoint;
    public Vector3 roundedImpactPoint;

    private Vector3 lastMousePos;
    private InventoryManagerUI inventoryManagerUI;
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
        if(Input.GetMouseButtonDown(0) && target != null && !eventSystem.IsPointerOverGameObject())
        {
            target.GetComponent<Interactable>().Interact(gameObject);
            indicator.transform.position = new Vector3(0, -100, 0);
            fenceIndicator.transform.position = new Vector3(0, -100, 0);
            farmlandIndicator.transform.position = new Vector3(0, -100, 0);
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
        // Only Raycasts if mouse is moving, or player is moving
        if (lastMousePos != Input.mousePosition || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            target = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Racast
            RaycastHit[] hits = Physics.SphereCastAll(ray, 0.05f);
            // Sort array by distance
            Array.Sort(hits, new RaycastComparer());


            // Checks every raycast until it finds correct one
            foreach (RaycastHit hit in hits)
            {
                // Checks if Element is selected, and is an Item
                if (inventoryManagerUI.selectedElement != null && inventoryManagerUI.selectedElement.item != null)
                {
                    lastRaycastImpactPoint = hit.point;
                    // Rounds the impactpoint coordinates up to "Grid"
                    roundedImpactPoint = new Vector3(Mathf.Round(hit.point.x * 2), hit.point.y * 2, Mathf.Round(hit.point.z * 2)) / 2;
                    // checks if Item is of the type"Seed"
                    if (inventoryManagerUI.selectedElement.item.itemType == Item.ItemType.Seed)
                    {
                        // checks if field is hit, and eligable to be planted on
                        if (hit.collider.CompareTag("Field") && hit.collider.GetComponent<Interactable_Field>().isEnabled)
                        {
                            indicator.transform.position = hit.collider.gameObject.transform.position;
                            lastMousePos = Input.mousePosition;
                            target = hit.collider.gameObject;
                            return;
                        }
                    }
                    // Checks if the Item is of the type "Other"
                    if (inventoryManagerUI.selectedElement.item.itemType == Item.ItemType.Other)
                    {
                        // Checks if stone is hit, if true, it cancles
                        if (hit.collider.CompareTag("Stone"))
                        {
                            break;
                        }
                        // Checks if floor is hit
                        if (hit.collider.CompareTag("Floor"))
                        {
                            // Chooses Item, depending on the item selected by the inventoryManager
                            switch (inventoryManagerUI.selectedElement.item.itemName)
                            {
                                case "Fence":
                                    ResetProjectionPositions();
                                    currentObjectIndicator = fenceIndicator;
                                    break;
                                case "Farmland":
                                    ResetProjectionPositions();
                                    currentObjectIndicator = farmlandIndicator;
                                    break;
                            }
                            // Place indicator
                            currentObjectIndicator.transform.position = roundedImpactPoint;
                            lastMousePos = Input.mousePosition;
                            target = hit.collider.gameObject;
                            return;
                        }
                    }
                }
            }
            // Reset postions
            ResetProjectionPositions();
        }
        lastMousePos = Input.mousePosition;
    }

    /// <summary>
    /// Resets the Postion of the Projections - By Christian Scherzer
    /// </summary>
    private void ResetProjectionPositions()
    {
        indicator.transform.position = new Vector3(0, -100, 0);
        fenceIndicator.transform.position = new Vector3(0, -100, 0);
        farmlandIndicator.transform.position = new Vector3(0, -100, 0);
    }

    class RaycastComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((RaycastHit)x).distance, ((RaycastHit)y).distance);
        }
    }
}
