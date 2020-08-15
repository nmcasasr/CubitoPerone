using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsInputEnabled = true;
    public GameObject Player;
    public GameObject Canvas;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        IsInputEnabled = true;
    }

    // Update is called once per frame
    public static void PlayerDead()
    {
        
        GameManager.IsInputEnabled = false;
        //GameObject.Find("DeadCanvas").SetActive(true);

    }
}
