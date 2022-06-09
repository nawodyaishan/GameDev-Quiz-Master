using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void ShowFinalScore()
    {
        finalScoreText.text =
            ($"Hehe, Not Bad.. Not terrible...\n\nCongratulations !!\n\nYour Score is {scoreKeeper.CalculateScore()}%");
    }
}
