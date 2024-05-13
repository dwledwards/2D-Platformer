using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumpForce;
    Rigidbody2D rb;
    float xInput;
    bool isGrounded;
    bool doubleJump = true;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (xInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                Jump();
            } 
            else
            {
                if(doubleJump)
                {
                    DoubleJump();
                    doubleJump = false;
                } 
            }
        }

        if(isGrounded && !doubleJump)
        {
            doubleJump = true;
        }

        animator.SetBool("isGounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        CheckDirection();
    }

    void CheckDirection()
    {
        if(rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if(rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce/2);
    }
}
