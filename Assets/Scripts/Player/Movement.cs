using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float xMov, yMov;
    BoxCollider2D bc;
    public float speed, force;
    public bool isGrounded;

    GameObject go;
    Vector2 originalBCSize;
    Vector2 originalBCOffset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        originalBCSize = bc.size;
        originalBCOffset = bc.offset;
    }

    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xMov, rb.velocity.y / speed) * speed;
        
        if(Input.GetKey(KeyCode.S))
        {
            bc.size = new Vector2(originalBCSize.x, originalBCSize.y * 0.8f);
            bc.offset = new Vector2(originalBCOffset.x, 0.02f);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            bc.size = originalBCSize;
            bc.offset = originalBCOffset;
        }
    }
}
