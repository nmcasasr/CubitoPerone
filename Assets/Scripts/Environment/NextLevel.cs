using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject respawnManager;

    private void Start() {
      respawnManager = GameObject.FindGameObjectWithTag("LevelManager");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            respawnManager.gameObject.GetComponent<MenuController>().LoadNextScene();
        }
    }
}
