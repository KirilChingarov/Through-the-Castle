using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;

    private Rigidbody2D rb;
    private Transform playerTransform;
    public float moveSpeed = 5f;

    private bool isGrounded = false;
    public float jumpForce = 5f;

    private bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float input = 0f;
        if (Input.GetKey("d"))
        {
            input = 1f;
        }
        if (Input.GetKey("a"))
        {
            input = -1f;
        }

        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);
        playerAnimator.SetFloat("Player_speed", Mathf.Abs(input));

        Flip(input);

        Jump();
    }

    void Flip(float input)
    {
        if (facingRight == false && input > 0)
        {
            facingRight = !facingRight;
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, playerTransform.localScale.y, playerTransform.localScale.z);
        }
        if (facingRight && input < 0)
        {
            facingRight = !facingRight;
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, playerTransform.localScale.y, playerTransform.localScale.z);
        }
    }

    void Jump()
    {
        if(isGrounded && Input.GetKey("space"))
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            playerAnimator.SetBool("isJumping", !isGrounded);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            playerAnimator.SetBool("isJumping", !isGrounded);
        }
    }

    public bool isPlayerGrounded()
    {
        return isGrounded;
    }
}
