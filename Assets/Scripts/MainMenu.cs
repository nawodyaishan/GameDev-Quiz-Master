using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    void ShowFinalScore()
    {
        finalScoreText.text =
            ($"Hehe, Not Bad.. Not terrible...\n\nCongratulations !!\n\nYour Score is {scoreKeeper.CalculateScore()}%");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/nawodyaishan/GameDev-Quiz-Master");
    }
}