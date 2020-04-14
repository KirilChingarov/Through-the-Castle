using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private Transform enemy;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D rbConstraints;
    private Animator enemyAnimator;

    public GameObject aggroRange;
    private AggroController aggro;

    public float enemySpeed = 3f;

    private bool targetReached = false;
    private bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        aggro = aggroRange.GetComponent<AggroController>();
        enemy = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rbConstraints = rb.constraints;
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!aggro.isPlayerInAggro())
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            enemyAnimator.SetFloat("EnemySpeed", Mathf.Abs(0f));
            return;
        }
        if (GetComponent<EnemyController>().isEnemyDead()) return;

        float direction = getDirection();

        rb.velocity = new Vector2(direction * enemySpeed, rb.velocity.y);
        enemyAnimator.SetFloat("EnemySpeed", Mathf.Abs(direction));

        Flip(direction);
    }

    float getDirection()
    {
        if (targetReached) return 0f;

        if (target.position.x > enemy.position.x)
        {
            return 1f;
        }
        else return -1f;
    }

    void Flip(float direction)
    {
        if (facingRight == false && direction > 0)
        {
            facingRight = !facingRight;
            enemy.localScale = new Vector3(enemy.localScale.x * -1, enemy.localScale.y, enemy.localScale.z);
        }
        if (facingRight == true && direction < 0)
        {
            facingRight = !facingRight;
            enemy.localScale = new Vector3(enemy.localScale.x * -1, enemy.localScale.y, enemy.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetReached = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetReached = false;
        }
    }

    public void freezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void unfreezePosition()
    {
        //rb.constraints = RigidbodyConstraints2D.None;
        //rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        rb.constraints = rbConstraints;
    }
}
