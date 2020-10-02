using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    bool playerInRange;
    public bool thisDialogueDone;

    private void Update()
    {
        continueTalk();
    }

    void continueTalk()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();

            if (FindObjectOfType<DialogueManager>().convoDone == true)
            {
                FindObjectOfType<DialogueManager>().convoDone = false;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (FindObjectOfType<DialogueManager>().convoDone == true)
        {
            thisDialogueDone = true;
            FindObjectOfType<DialogueManager>().anim.SetBool("isOpen", false);
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
