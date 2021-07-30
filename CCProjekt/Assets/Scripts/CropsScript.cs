using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsScript : MonoBehaviour
{

    public List<GameObject> cropStages;
    public int currentCropStage = 0;
    public float growthSpeed = 2;
    public Interactable myInteractable;

    private GameObject currentCropObjet;
    // Start is called before the first frame update
    void Start()
    {
        PlantCrop();
    }


    /// <summary>
    /// Progreses the current crop stage
    /// by Christian Scherzer
    /// </summary>
    public void ProgressCropStage()
    {

        // If crop isn't fully grown, progress cropgrowth
        if (currentCropStage < cropStages.Count-1)
        {
            currentCropObjet.SetActive(false);
            currentCropStage++;
            currentCropObjet = cropStages[currentCropStage];
            currentCropObjet.SetActive(true);
        }

        // if crop is fully grown, cancel the growth and make it interactable
        if (currentCropStage >= cropStages.Count-1)
        {
            myInteractable.isEnabled = true;
            CancelInvoke("ProgressCropStage");
        }
    }


    /// <summary>
    /// Plants the Crop
    /// - By Christian Scherzer
    /// </summary>
    public void PlantCrop()
    {
        currentCropObjet = cropStages[currentCropStage];
        InvokeRepeating("ProgressCropStage", growthSpeed, growthSpeed);
    }

    /// <summary>
    /// Reset the Crop
    /// - By Christian Scherzer
    /// </summary>
    public void ResetCrop()
    {
        foreach (GameObject cropStage in cropStages)
        {
            cropStage.SetActive(false);
        }
        CancelInvoke("ProgressCropStage");
        myInteractable.isEnabled = false;
        currentCropStage = 0;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Destroys the crop, and reanables the field to be planted again
    /// By Christian Scherzer
    /// </summary>
    public void DeathEvent()
    {
        GetComponent<Interactable_Crop>().field.isEnabled = true;
        Destroy(gameObject);
    }
}
