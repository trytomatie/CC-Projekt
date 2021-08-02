using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI difficultyText;
    public GameObject titleScreen;
    public GameObject howToPlayText;
    public TextMeshProUGUI highscore;

    private int difficulty = 0;

    private void Start()
    {
        titleScreen.SetActive(true);
        howToPlayText.SetActive(false);

        int highscoreDays = PlayerPrefs.GetInt("highscoreDays", 0);
        int highscoreCrops = PlayerPrefs.GetInt("highscoreCrops", 0);
        highscore.text = "Highscore: \n" +
            "Days Survived: " + highscoreDays + "\n" +
            "Crops Sold: " + highscoreCrops;
    }

    /// <summary>
    /// Starts Application
    /// By Shaina Milde
    /// </summary>
    public void StartGame()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Closes Application
    /// By Shaina Milde
    /// </summary>
    public void QuitGame ()
    {
        Application.Quit();
    }

    /// <summary>
    /// Decreases difficulty
    /// By Shaina Milde
    /// </summary>
    public void LeftButton ()
    {
        difficulty = difficulty - 1;

        if(difficulty < 0) 
        {
            difficulty = 2;
        }

        ChangeDifficultyText();
    }

    /// <summary>
    /// Increases difficulty
    /// By Shaina Milde
    /// </summary>
    public void RightButton()
    {
        difficulty = difficulty + 1;

        if (difficulty > 2)
        {
            difficulty = 0;
        }

        ChangeDifficultyText();
    }

    /// <summary>
    /// Opens the HowToPlay screen
    /// By Shaina Milde
    /// </summary>
    public void HowToPlay ()
    {
        titleScreen.SetActive(false);
        howToPlayText.SetActive(true);
    }

    /// <summary>
    /// Returns to Titlescreen
    /// By Shaina Milde
    /// </summary>
    public void ReturnToTitle ()
    {
        titleScreen.SetActive(true);
        howToPlayText.SetActive(false);
    }

    /// <summary>
    /// Changes text depending on the difficulty
    /// By Shaina Milde
    /// </summary>
    private void ChangeDifficultyText ()
    {
        switch (difficulty)
        {
            case 0:
                difficultyText.text = "Easy";
                break;

            case 1:
                difficultyText.text = "Normal";
                break;

            case 2:
                difficultyText.text = "Hard";
                break;
        }
    }
}
