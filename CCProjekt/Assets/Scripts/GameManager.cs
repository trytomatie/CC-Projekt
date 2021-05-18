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
    public static GameManager instance;
    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameCamera = Camera.main;
    }


    public static void SpawnFloatingText(string text,Transform targetTransform)
    {
        GameObject go = Instantiate(instance.damageText, instance.gameCamera.WorldToScreenPoint(targetTransform.position + new Vector3(0, 1, 0)), instance.damageText.transform.rotation, instance.canvas.transform);
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
}
