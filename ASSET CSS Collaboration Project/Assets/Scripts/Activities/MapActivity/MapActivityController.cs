﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapActivityController : MonoBehaviour
{
    public static MapActivityController instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject answerPanel;
    public GameObject gameEndPanel;

    [Header("Answering Stuff")]
    public string[] correctAnswer;
    public TMP_InputField inputAnswer;
    public Image countryImage;
    public Button currentButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        answerPanel.SetActive(false);
        gameEndPanel.SetActive(false);
    }

    public void Update()
    {
        if(score == 11)
        {
            gameEndPanel.SetActive(true);
        }
    }

    public void addScore()
    {
        score++;

        AudioManager.instance.Play("CorrectSound");
        scoreText.text = score + "/11";
        currentButton.interactable = false;
        answerPanel.SetActive(false);
    }

    public void checkAnswer()
    {
        string answer = inputAnswer.text;

        bool answerCorrect = false;

        foreach (string possibleAnswer in correctAnswer)
        {
            if (answer == possibleAnswer)
            {

                answerCorrect = true;
                break;
            }
            else
            {
                answerCorrect = false;
            }
        }

        if (answerCorrect)
        {
            addScore();
        }
        else
        {
            AudioManager.instance.Play("WrongSound");
        }
    }

    public void openAnswerPanel()
    {
        answerPanel.SetActive(true);
    }

    public void gameEnd()
    {
        SceneManager.LoadScene("Day2");
    }
}
