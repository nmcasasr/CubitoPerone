using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInput : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canMove;
    void Start()
    {
        GameManager.IsInputEnabled = false;
    }
    void Update()
    {
        if (canMove)
        {
            GameManager.IsInputEnabled = true;
        } else
        {
            GameManager.IsInputEnabled = false;
        }
    }
}
