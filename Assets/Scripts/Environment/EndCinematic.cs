using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCinematic : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject respawnManager;
    public bool isFinal;
    void Start()
    {
        respawnManager = GameObject.FindGameObjectWithTag("LevelManager");
        respawnManager.gameObject.GetComponent<MenuController>().LoadNextScene();
    }
}
