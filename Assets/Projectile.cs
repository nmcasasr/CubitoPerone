using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Player player = collider.gameObject();
        //if (player != null)
        //{
        //TODO: Take Damage Logic
        //Destroy(gameObject);
        //}
    }

}
