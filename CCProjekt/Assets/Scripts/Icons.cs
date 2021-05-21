using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    public Sprite[] icons;

    public static Icons instance;

    private void Awake()
    {
        instance = GameObject.FindObjectOfType<Icons>();
    }
    public static Sprite GetIcon(int id)
    {
        return instance.icons[id];
    }
}
