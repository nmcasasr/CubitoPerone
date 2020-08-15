using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); 
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
