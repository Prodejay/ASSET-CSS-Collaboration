using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Country : MonoBehaviour
{
    public string[] correctAnswer;
    public Sprite countryImage;
    private Button thisButton;

    private void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
    }

    public void sendData()
    {
        MapActivityController.instance.correctAnswer = correctAnswer;
        MapActivityController.instance.countryImage.sprite = countryImage;
        MapActivityController.instance.currentButton = thisButton;
        MapActivityController.instance.openAnswerPanel();
    }
}
