using System.Collections;
using System.Collections.Generic;
using Questions;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;

    void Start()
    {
        questionText.text = question.GetQuestion();
    }
}