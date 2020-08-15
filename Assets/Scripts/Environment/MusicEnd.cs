using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEnd : MonoBehaviour
{
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        if(!(index == 0))
        {
            DontDestroyOnLoad(gameObject); /// taken from this Tutorial https://youtu.be/x9lguwc0Pyk
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            Destroy(gameObject);
        }
    }
}
