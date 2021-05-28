using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool ConversationActive = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioManager.instance.Play("MainMenu");    
    }

    public void playGame()
    {
        AudioManager.instance.Stop("MainMenu");
        SceneManager.LoadScene("Day1-Pt. 1");

        AudioManager.instance.Play("InGame");
    }
}
