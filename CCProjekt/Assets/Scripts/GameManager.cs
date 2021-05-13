using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject damageText;
    public GameObject worldSpaceCanvas;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    public static void SpawnFloatingText(string text,Transform targetTransform)
    {
        GameObject go = Instantiate(instance.damageText, targetTransform.position + new Vector3(0, 1, 0), instance.damageText.transform.rotation, instance.worldSpaceCanvas.transform);
        go.GetComponent<TextMeshProUGUI>().text = text;
    }
}
