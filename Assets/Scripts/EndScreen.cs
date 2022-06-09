using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void ShowFinalScore()
    {
        finalScoreText.text =
            ($"Hehe, Not Bad.. Not terrible...\n\nCongratulations !!\n\nYour Score is {scoreKeeper.CalculateScore()}%");
    }
}