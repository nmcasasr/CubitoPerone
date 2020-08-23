using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss;
    public bool activate = false;
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            if (boss)
            {
            boss.GetComponent<Animator>().SetBool("IsIntro", true);
            }
            
        } else
        {
            if (boss)
            {
            boss.GetComponent<Animator>().SetBool("IsIntro", false);
            }
            
        }
    }
}
