using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject damageText;
    public GameObject canvas;
    public TextMeshProUGUI creditText;
    public GameObject gameOverDialog;
    public GameObject pauseDialog;
    public GameObject soundObject;
    public GameObject damageObject;
    public TextMeshProUGUI daysText;

    public DayNightCycler dayNightCycler;

    public bool isGameOver = false;
    public bool isPaused = false;

    public int difficulty = -1;
    public float cropYieldMultipier = 1;
    public float growthMulitiplier = 1;

    public SpawnManager spawnManager;

    private int credits = 0;
    private static GameManager instance;
    private Camera gameCamera;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        gameCamera = Camera.main;

        difficulty = PlayerPrefs.GetInt("difficulty", 1);


        // Changes the Multiplier depending on the difficulty
        switch (difficulty)
        {
            case 0:
                cropYieldMultipier = 1.3f;
                break;
            case 1:
                cropYieldMultipier = 1f;
                break;
            case 2:
                cropYieldMultipier = 0.7f;
                break;
        }

        switch (difficulty)
        {
            case 0:
                growthMulitiplier = 1.3f;
                break;
            case 1:
                growthMulitiplier = 1f;
                break;
            case 2:
                growthMulitiplier = 0.7f;
                break;
        }

        gameOverDialog.SetActive(false); // game over dialog & pause dialog will not be display at the beginning of the game
        pauseDialog.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver) // if the player presses the escape key and isnt game over, he can pause the game
        {
            PauseGame(!isPaused);
        }
    }

    /// <summary>
    /// Spawns floating ui-text
    /// By Christian Scherzer
    /// </summary>
    /// <param name="text"></param>
    /// <param name="targetTransform"></param>
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

    /// <summary>
    /// game over
    /// by Shaina Milde
    /// </summary>
    public void SetGameOver()
    {
        isGameOver = true;
        daysText.text = "Days survived: " + dayNightCycler.realDayCount;
        gameOverDialog.SetActive(true); // game over dialog will be displayed

        Time.timeScale = 0;             // freezes the game

        spawnManager.CancelInvoke();    // all invokes from the spawnmanager will be stopped
    }

    /// <summary>
    /// restarts the game
    /// By Shaina Milde
    /// </summary>
    public void RestartGame ()
    {
        Time.timeScale = 1;     //makes sure that time scale is set to 1       

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // game scene will be reloaded
    }
    
    /// <summary>
    /// pauses the game
    /// By Shaina Milde
    /// </summary>
    public void PauseGame (bool setPause)
    {
        if(ShopUI.Instance.gameObject.activeSelf == true)
        {
            ShopUI.CloseShopUI();
            return;
        }
        isPaused = setPause;

        pauseDialog.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0; // if game gets paused, time will freeze
        }
        else
        {
            Time.timeScale = 1; //unfreezes time
        }
        
    }

    /// <summary>
    /// returns to title screen
    /// By Shaina Milde
    /// </summary>
    public void BackToTitle ()
    {
        Time.timeScale = 1; //makes sure that time scale is set to 1

        SceneManager.LoadScene(0); // title menu will be loaded
    }

    public static GameManager Instance { get => instance; private set => instance = value; }
}


