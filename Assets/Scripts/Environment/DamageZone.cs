using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        collision.gameObject.GetComponent<PlayerHealth>().takeDamage(100000);
        }
        
    }
}
