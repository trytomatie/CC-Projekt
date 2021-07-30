using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int difficulty = 0;
    public TextMeshProUGUI difficultyText;

    /// <summary>
    /// Starts Application
    /// </summary>
    public void StartGame()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Closes Application
    /// </summary>
    public void QuitGame ()
    {
        Application.Quit();
    }

    /// <summary>
    /// Decreases difficulty
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
    /// Changes text depending on the difficulty
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
