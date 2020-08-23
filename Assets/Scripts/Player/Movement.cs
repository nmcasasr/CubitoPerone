using System.Collections;
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
    public bool bCanJump;
    AnimationsController aController;
    [SerializeField] private LayerMask platformLayerMask;

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
        if (GameManager.IsInputEnabled)
        {
        xMov = Input.GetKey(KeyCode.A)?-1:Input.GetKey(KeyCode.D)?1:0;
        //yMov = Input.GetAxis("Jump") * speed;
        yMov = Input.GetKey(KeyCode.A)?1:0;

        rb.velocity = new Vector2(xMov, rb.velocity.y/speed) * speed;
        //print(""+rb.velocity+ " " +speed);

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
        if (Input.GetAxis("Jump")>0 && IsGrounded())
        {
            yMov = Input.GetAxis("Jump") * force;
            rb.velocity = rb.velocity = new Vector2(rb.velocity.x, yMov);
        }
        }
        aController.bIsGrounded = IsGrounded();

    }
    private bool IsGrounded()
    {
        float height = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size - new Vector3(0.5f, 0f, 0f), 0f, Vector2.down, height, platformLayerMask);
        Color raycolor;
        if (raycastHit.collider != null)
        {
            raycolor = Color.green;
        } else
        {
            raycolor = Color.red;
        }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + height), raycolor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + height), raycolor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y+height), Vector2.right * (bc.bounds.extents.x), raycolor);
        //Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + height), raycolor);
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bCanJump = IsGrounded();
       /// aController.bIsGrounded = IsGrounded();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ///bCanJump = !(IsGrounded());
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       /// bCanJump = (IsGrounded());
       /// aController.bIsGrounded = (IsGrounded());
    }
}
