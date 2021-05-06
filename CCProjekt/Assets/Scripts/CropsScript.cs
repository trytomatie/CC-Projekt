using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsScript : MonoBehaviour
{

    public List<GameObject> cropStages;
    public int currentCropStage = 0;
    private GameObject currentCropObjet;
    // Start is called before the first frame update
    void Start()
    {
        currentCropObjet = cropStages[currentCropStage];
        currentCropObjet.SetActive(true);
        InvokeRepeating("ProgressCropStage", 3, 2);
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

        if (currentCropStage + 1 < cropStages.Count)
        {
            currentCropObjet.SetActive(false);
            currentCropStage++;
            currentCropObjet = cropStages[currentCropStage];
            currentCropObjet.SetActive(true);
        }
        else
        {
            print("Crop fully grown");
            CancelInvoke("ProgressCropStage");
        }
    }
}
