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
    /// <summary>
    /// Harvest crop and give seeds and Crops to the player
    /// By Christian Scherzer
    /// </summary>
    /// <param name="interactor"></param>
    public override void Interact(GameObject interactor)
    {
        GameManager.Instance.SpawnInterfaceSound(GameManager.Instance.plopSound, 0.2f);

        if (Random.Range(0, 101) < 25 )
        {
            interactor.GetComponent<InventoryManager>().AddItem((Item)ScriptableObject.CreateInstance(seedDrop));
        } 
        interactor.GetComponent<InventoryManager>().AddItem((Item)ScriptableObject.CreateInstance(cropDrop));
        field.isEnabled = true;

        Destroy(gameObject);
    }
}
