using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float Jumpforce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObject;
    public float checkRadius;
    public int maxJumpCount;


    private Rigidbody2D rb;
    private float moveDirection;
    private bool facingRight;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpcount;


    private void Start()
    {
        jumpcount = maxJumpCount;

    }

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

    }


     void Update()
    {
        ProcessInputs();

        Animate();


        

    }


     private void FixedUpdate()
    {
        Move();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);
        if(isGrounded)
        {

            jumpcount = maxJumpCount;


        }
    }


    private void Move()

    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, Jumpforce));
            jumpcount--;
        }
            isJumping = false;
    }


    private void Animate()

    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }

    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")&& jumpcount>0)
        {
            isJumping = true;
        }


    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;

    }


    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        transform.parent = col.transform;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="MovingPlatform")
        {
            transform.parent = null;
        }
    }

}   