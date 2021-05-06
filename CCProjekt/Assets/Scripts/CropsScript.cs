using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsScript : MonoBehaviour
{

    public List<GameObject> cropStages;
    public int currentCropStage = 0;
    public float growthSpeed = 2;
    private GameObject currentCropObjet;
    public Interactable myInteractable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Progesses the current crop stage
    /// by Christian Scherzer
    /// </summary>
    public void ProgressCropStage()
    {

        if (currentCropStage < cropStages.Count-1)
        {
            currentCropObjet.SetActive(false);
            currentCropStage++;
            currentCropObjet = cropStages[currentCropStage];
            currentCropObjet.SetActive(true);
        }

        if (currentCropStage >= cropStages.Count-1)
        {
            myInteractable.isEnabled = true;
            CancelInvoke("ProgressCropStage");
        }
    }



    public void PlantCrop()
    {
        ResetCrop();
        currentCropObjet = cropStages[currentCropStage];
        currentCropObjet.SetActive(true);
        gameObject.SetActive(true);
        InvokeRepeating("ProgressCropStage", growthSpeed, growthSpeed);
    }

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
}
