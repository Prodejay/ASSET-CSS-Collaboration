using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goHome : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Stop("InGame");

        AudioManager.instance.Play("GameOver");
    }
    public void goToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
