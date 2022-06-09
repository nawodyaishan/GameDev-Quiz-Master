using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int correctAnswers;
    private int questionsSeen;

    public int CorrectAnswer()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetQuestionsSeen()
    {
        return questionsSeen;
    }
    
    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        return Convert.ToInt32((float)correctAnswers/(float) questionsSeen * 100);
        // return Mathf.RoundToInt((float)correctAnswers/(float) questionsSeen * 100);
    }
    
}