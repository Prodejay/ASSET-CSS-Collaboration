using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI answerText;

    private AnswerData answerData;
    private MultipleChoiceGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<MultipleChoiceGameController>();
    }

    public void SetUp(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        gameController.answerButtonClicked(answerData.isCorrect);
    }
}
