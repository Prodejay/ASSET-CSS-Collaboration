using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapActivityController : MonoBehaviour
{
    public static MapActivityController instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
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

    public void addScore()
    {
        score++;

        scoreText.text = score + "/11";
    }
}
