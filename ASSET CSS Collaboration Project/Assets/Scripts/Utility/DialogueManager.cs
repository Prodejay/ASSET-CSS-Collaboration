using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Animator anime;

    public bool convoFinished;

    [HideInInspector]
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        anime = GetComponent<Animator>();

        anime.SetBool("openDialogue", false);
    }

    public void StartConvo(Dialogue dialogue)
    {
        anime.SetBool("openDialogue", true);

        StartCoroutine(loadDialoguePanel());

        GameController.instance.ConversationActive = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndConvo()
    {
        convoFinished = true;

        StartCoroutine(loadDialoguePanel());
        anime.SetBool("openDialogue", false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        if (sentences.Count == 0)
        {
            EndConvo();
        }
    }

    IEnumerator loadDialoguePanel()
    {
        yield return new WaitForSeconds(20f);
    }
}

