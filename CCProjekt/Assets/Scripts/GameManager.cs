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

    private int credits = 0;
    private static GameManager instance;
    private Camera gameCamera;

    public bool isGameOver = false;
    public bool isPaused = false;

    public float difficutlyScaling = 1;

    public SpawnManager spawnManager;

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

        gameOverDialog.SetActive(false);
        pauseDialog.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            PauseGame(!isPaused);
        }
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

    public void SetGameOver()
    {
        isGameOver = true;
        gameOverDialog.SetActive(true);

        Time.timeScale = 0;

        spawnManager.CancelInvoke();
    }

    public void RestartGame ()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame (bool setPause)
    {
        isPaused = setPause;

        pauseDialog.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }

    public void BackToTitle ()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    public static GameManager Instance { get => instance; private set => instance = value; }
}


