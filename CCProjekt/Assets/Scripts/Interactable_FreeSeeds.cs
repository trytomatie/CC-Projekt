using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_FreeSeeds : Interactable
{
    public string[] seedDrops;
    public Item item;
    private void Start()
    {
        interactableText = "Pickup seed";
        // Generate Random Seed
        item = (Item)ScriptableObject.CreateInstance(seedDrops[Random.Range(0, seedDrops.Length)]);
    }

    /// <summary>
    /// Add Random seed to Inventory
    /// by Christian Scherzer and Shaina Milde
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        if(interactor.GetComponent<InventoryManager>().AddItem(item))
        {
            GameManager.Instance.SpawnInterfaceSound(GameManager.Instance.plopSound, 0.2f);
            Destroy(gameObject);
        }
        else
        {
            GameManager.SpawnFloatingText("Cannot pickup any more Items!", transform);
        }
    }

    private void Update()
    {
        // destroy Object if it's out of bounds
        if(transform.position.y > 100 || transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }
}
