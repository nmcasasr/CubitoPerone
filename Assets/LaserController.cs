using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public BoxCollider2D bc;
    public bool isActive = false;
    public bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            bc.enabled = true;
        } else
        {
            bc.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.gameObject.CompareTag("Player"))
            {
            if (canDamage)
            {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(2);
                canDamage = false;
            }
                
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canDamage = true;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (isActive)
    //    {
    //        print("Player enter");
    //        if (collision.gameObject.CompareTag("Player"))
    //        {
    //            print("Player enter2");
    //            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
    //            isActive = false;
    //        }
    //    }
    //}
}
