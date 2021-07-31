using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{

    public PlayerController player;


    private static ShopUI instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Closes Shop UI
    /// By Christian Scherzer
    /// </summary>
    public static void CloseShopUI()
    {
        Time.timeScale = 1;
        instance.gameObject.SetActive(false);
    }

    public static ShopUI Instance { get => instance; private set => instance = value; }

}
