using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool nextSentence = false;

    bool playerInRange;
    bool alreadyTalked;
    bool convoStarted;
    public bool thisDialogueDone;


    private void Start()
    {
        FindObjectOfType<DialogueManager>().convoFinished = false;
        alreadyTalked = false;
        convoStarted = false;
    }
    // Update is called once per frame
    void Update()
    {
        continueTalk();
    }

    public void goNextSentence()
    {
        nextSentence = true;
    }

    public void continueTalk()
    {
        if (!FindObjectOfType<DialogueManager>().convoFinished && nextSentence)
        {
            nextSentence = false;
            FindObjectOfType<DialogueManager>().DisplayNextSentence();

            if (FindObjectOfType<DialogueManager>().convoFinished)
            {
                thisDialogueDone = true;
                alreadyTalked = true;
            }
        }
    }

    void startTalk()
    {
        if (!FindObjectOfType<DialogueManager>().convoFinished)
        {
            if (!convoStarted)
            {
                FindObjectOfType<DialogueManager>().StartConvo(dialogue);
                convoStarted = true;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!alreadyTalked)
            {
                startTalk();
            }
        }
    }

    IEnumerator waitForStartConvo()
    {
        yield return new WaitForSeconds(3f);
    }
}
