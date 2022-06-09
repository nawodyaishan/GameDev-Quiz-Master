using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Questions;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    [Header("Question")] QuestionSO currentQuestion;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] private List<QuestionSO> questions = new List<QuestionSO>();

    [Header("Answer")] [SerializeField] private GameObject[] answerButtons;
    private int correctAnswerIndex;
    private bool hasAnsweredEarly = true;

    [Header("Button")] [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")] [SerializeField] private Image timerImage;
    private Timer timer;

    [Header("Scoring"), SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    [Header("Progress Bar"), SerializeField]
    private Slider progressBar;
    [SerializeField] private bool quizIsComplete;


    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {
        FillAmountChange();

        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1); // Automatically falls in to else condition
            SetButtonState(false);
        }
    }


    private void FillAmountChange()
    {
        timerImage.fillAmount = timer.fillFraction;
    }

    void AnswersToButton()
    {
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score : " + scoreKeeper.CalculateScore() + "%";

        if (progressBar.value == progressBar.maxValue)
        {
            quizIsComplete = true;
        }
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = ($"InCorrect Answer.. The correct answer is \n\"{correctAnswer}\" ");
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            AnswersToButton();

            progressBar.value++;
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
            questions.Remove(currentQuestion);
    }

    void SetButtonState(bool state)
    {
        foreach (var t in answerButtons)
        {
            Button button = t.GetComponent<Button>();
            button.interactable = state;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void SetDefaultButtonSprites()
    {
        foreach (var t in answerButtons)
        {
            var buttonImage = t.GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}