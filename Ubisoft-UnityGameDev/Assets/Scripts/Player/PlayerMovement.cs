using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform playerTransform;
    public float moveSpeed = 5f;

    public bool isGrounded = false;
    public float jumpForce = 5f;

    private bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);

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
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
