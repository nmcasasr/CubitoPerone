using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private GameObject player;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //TODO: Take Damage Logic
            player.GetComponent<PlayerHealth>().takeDamage(damage);
            Invoke("DestroyProjectile", 0f);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
