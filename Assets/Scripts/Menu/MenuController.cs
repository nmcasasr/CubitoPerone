using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool isFinal = false;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToHistoryScene()
    {
        SceneManager.LoadScene("History");
    }
    public void goToCreditsScene()
    {
        SceneManager.LoadScene("Credtis");
    }
    public void LoadNextScene()
    {
        if (isFinal)
        {
            StartCoroutine(LoadLevel(0));
        } else
        {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        }
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); 
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
