using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    private bool triggered = false;
    public TextMeshProUGUI textDisplay;
    public Image characterOne;
    public Image characterTwo;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public Animator anime;

    private void Start()
    {
        
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            anime.SetBool("openDialogue", false);
            GameController.instance.ConversationActive = false;
            continueButton.SetActive(false);
            textDisplay.text = "";
            triggered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            anime.SetBool("openDialogue", true);
            GameController.instance.ConversationActive = true;
            StartCoroutine(Type());
        }
        
    }
}
