using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeController : MonoBehaviour
{
    private bool movingRight, isLeft;
    private GameObject player;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    public int damage;

    public float speed;

    private bool canMelee, canMove;
    private Rigidbody2D meleeRb;

    void Start()
    {
        speed = 5f;
        player = GameObject.FindGameObjectWithTag("Player");
        meleeRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isLeft = player.transform.localPosition.x > transform.localPosition.x;

        if (isLeft && !movingRight)
        {
            Flip();
        }
        else if (!isLeft && movingRight)
        {
            Flip();
        }

        if (canMove)
        {
            meleeRb.velocity = new Vector2((isLeft ? 0.1f : -0.1f) * speed, meleeRb.velocity.y / speed) * speed;
            print("Movement");
        }

        if (timeBtwAttack <= 0)
        {
            if (canMelee)
            {
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                foreach (var entity in playerToDamage)
                {
                    if (entity.gameObject.CompareTag("Player"))
                    {
                        entity.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
                        //Debug.Log(entity.gameObject.GetComponent<PlayerHealth>());
                        //Debug.Log("Player Took Damage!");
                    }
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    
    public void setMelee(bool val)
    {
        canMelee = val;
    }

    public void setMove(bool val)
    {
        print("Move modified");
        canMove = val;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private void Flip()
    {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
