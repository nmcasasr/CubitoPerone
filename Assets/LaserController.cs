using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public BoxCollider2D bc;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("trigger");
        if (isActive)
        {
            print("Player enter");
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
                isActive = false;
            }
        }
    }
}
