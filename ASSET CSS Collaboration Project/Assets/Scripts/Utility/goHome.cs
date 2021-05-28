using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goHome : MonoBehaviour
{
    public GameObject fade;
    private void Start()
    {
        fade.SetActive(true);
        AudioManager.instance.Stop("InGame");

        AudioManager.instance.Play("GameOver");

        StartCoroutine(turnOffFadeToBlack());
    }
    public void goToTitle()
    {
        AudioManager.instance.Stop("GameOver");
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator turnOffFadeToBlack()
    {
        yield return new WaitForSeconds(1f);
        fade.SetActive(false);
    }
}
