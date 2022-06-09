using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeForCompleteQuestion;

    [SerializeField] private float timeForShowCorrectAnswer;

    public bool loadNextQuestion = false;

    private float timerValue;

    public bool isAnsweringQuestion = false;

    public float fillFraction;

    void Update() => UpdateTimer();

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeForCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeForShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeForShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeForCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        Debug.Log($"Time remaining = {timerValue} {isAnsweringQuestion} \n {fillFraction}");
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}