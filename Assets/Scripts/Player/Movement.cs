﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    float xMov;
    float yMov;
    public float speed;
    public float force;
    public bool isGrounded;
    GameObject go;
    GameObject player;
    Vector2 initBCSize;
    Vector2 initBCOffeset;
    bool bCanJump;
    AnimationsController aController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        aController = GetComponent<AnimationsController>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        go = gameObject;
        initBCSize = bc.size;
        initBCOffeset = bc.offset;
    }

    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxis("Horizontal") * speed;
        yMov = Input.GetAxis("Jump") * speed;
        rb.velocity = new Vector2(xMov, rb.velocity.y/speed) * speed;

        if (Input.GetKey(KeyCode.S))
        {
            bc.size = new Vector2(initBCSize.x, initBCSize.y/2);
            bc.offset = new Vector2(initBCOffeset.x, initBCOffeset.y - initBCSize.y / 4);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            bc.size = new Vector2(initBCSize.x, initBCSize.y);
            bc.offset = new Vector2(initBCOffeset.x, initBCOffeset.y);
        }
        if (Input.GetAxis("Jump")>0 && bCanJump)
        {
            yMov = Input.GetAxis("Jump") * force;
            rb.velocity = rb.velocity = new Vector2(rb.velocity.x, yMov);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bCanJump = (collision.gameObject.CompareTag("Platform"));
        aController.bIsGrounded = (collision.gameObject.CompareTag("Platform"));
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        bCanJump = !(collision.gameObject.CompareTag("Platform"));
    }
}
