﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public EnemyController parent;
    public bool Dialog = false;

    void Start()
    {
        parent = GetComponentInParent<EnemyController>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (Dialog)
            {
                parent.GetComponentInParent<DialogueTrigger>().TriggerDialog();
            }
            parent.setShoot(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            parent.setShoot(false);
        }
    }
}
