using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MultipleChoiceGameController : MonoBehaviour
{
    [Header("UI Stuff")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;

    [Header("Other Stuff")]
    public SimpleObjectPool answerButtonPool;
    public Transform answerButtonHolder;
    public GameObject questionDisplay;
    public GameObject answerDisplay;

    [Header("Round Data")]
    public RoundData roundData;

    [Header("Round End Stuff")]
    public GameObject RoundEndPanel;
    public TextMeshProUGUI RoundEndText;

    private bool isRoundActive = true;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    private QuestionData[] questionPool;
    private void Start()
    {
        RoundEndPanel.SetActive(false);

        questionPool = roundData.questionData;

        playerScore = 0;
        questionIndex = 0;

        showQuestion();
        isRoundActive = true;
    }

    private void showQuestion()
    {
        removeAnswerButtons();

        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        //part that puts answers in answer panel
        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonHolder);
            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }

    private void removeAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void answerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += roundData.pointsPerCorrectAnswer;
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else
        {
            //wrong signals
        }

        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            showQuestion();
        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        isRoundActive = false;

        RoundEndPanel.SetActive(true);
        RoundEndText.text = "You scored: " + playerScore.ToString();
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Day3-Pt. 2");
    }
}
