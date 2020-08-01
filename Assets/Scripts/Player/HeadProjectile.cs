using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }   
    
    void DestroyProjectile()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<Head>().setCanShoot(true);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInChildren<Head>().setCanShoot(true);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit Player");
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            //Destroy(gameObject);
        }
    }
}
