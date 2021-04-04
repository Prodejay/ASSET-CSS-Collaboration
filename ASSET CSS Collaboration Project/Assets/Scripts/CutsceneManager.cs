using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] pics;
    public Image currentImage;
    public GameObject FadeToBlack;

    private int picsIndex;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = FadeToBlack.GetComponent<Animator>();
        currentImage.sprite = pics[0];
        picsIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPicture()
    {
        if(picsIndex != pics.Length-1)
        {
            anime.SetTrigger("Transition");
            picsIndex++;
            StartCoroutine(changePicture(0.8f));
        }
        else
        {
            //go to activity
        }
        
    }

    IEnumerator changePicture(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentImage.sprite = pics[picsIndex];
    }
}
