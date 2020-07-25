using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    SpriteRenderer sprite;
    public bool bIsGrounded;
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bIsGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("bIsWalking", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                sprite.flipX = false;
            } else
            {
                sprite.flipX = true;
            }
            animator.SetBool("bIsWalking", true);
        }

        if (Input.GetAxis("Jump") > 0)
        {
            animator.SetBool("bIsJumping", true);
            animator.SetBool("bIsGrounded", false);
            bIsGrounded = false;
        }
        if (bIsGrounded)
        {
            print("dassad");
            animator.SetBool("bIsJumping", false);
            animator.SetBool("bIsGrounded", true);
        }
    }
}
