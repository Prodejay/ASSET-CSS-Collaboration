using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Country : MonoBehaviour
{
    public string[] correctAnswer;

    public TMP_InputField inputAnswer;

    public bool answeredCorrectly;

    public void checkAnswer()
    {
        string answer = inputAnswer.text;

        foreach(string possibleAnswer in correctAnswer)
        {
            if(answer == possibleAnswer)
            {

            }
        }
    }
}
