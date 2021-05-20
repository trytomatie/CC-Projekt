using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject damageText;
    public GameObject canvas;
    public TextMeshProUGUI creditText;
    private int credits = 0;
    private static GameManager instance;
    private Camera gameCamera;
    public float difficutlyScaling = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        gameCamera = Camera.main;
    }


    public static void SpawnFloatingText(string text,Transform targetTransform)
    {
        GameObject go = Instantiate(Instance.damageText, Instance.gameCamera.WorldToScreenPoint(targetTransform.position + new Vector3(0, 1, 0)), Instance.damageText.transform.rotation, Instance.canvas.transform);
        go.GetComponent<TextMeshProUGUI>().text = text;
    }

    public int Credits 
    { 
        get => credits; 
        set
        {
            credits = value;
            creditText.text = "Credits: " + credits;
        }
    }

    public static GameManager Instance { get => instance; private set => instance = value; }
}
