using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Crop : Interactable
{
    public List<GameObject> crops;

    public string seedDrop;
    public string cropDrop;

    public Interactable_Field field;
    private CropsScript cropScript;

    private void Start()
    {
        interactableText = "Harvest";
        cropScript = GetComponent<CropsScript>();
    }
    public override void Interact(GameObject interactor)
    {
        Destroy(gameObject);
        interactor.GetComponent<InventoryManager>().AddItem((Item)ScriptableObject.CreateInstance(seedDrop));
        interactor.GetComponent<InventoryManager>().AddItem((Item)ScriptableObject.CreateInstance(cropDrop));
        field.isEnabled = true;
    }
}
