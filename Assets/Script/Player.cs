using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public float jumpForce;
    private float moveInput;

    public Joystick joystick;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
        
    private void FixedUpdate()
    {
        moveInput = joystick.Horizontal;

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight==false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
    }
    private void Update()
    {
        float verticalMove = joystick.Vertical;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && verticalMove >= .5f)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeoF");
        }
        if (isGrounded == true)
        {
            anim.SetBool("IsJumping",false);
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
       /*
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
    }
}