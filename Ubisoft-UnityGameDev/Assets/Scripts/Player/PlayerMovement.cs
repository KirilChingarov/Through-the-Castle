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
        if (GetComponent<PlayerController>().getHealth() <= 0) return;

        float input = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            input = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input = -1f;
        }

        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(input));

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
        if(isGrounded && Input.GetKey(KeyCode.Space))
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

    public void freezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void unfreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
