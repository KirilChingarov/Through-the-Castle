using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private Transform enemy;
    private Rigidbody2D rb;
    private Animator enemyAnimator;

    public GameObject aggroRange;
    private AggroController aggro;

    public float enemySpeed = 3f;

    public bool targetReached = false;
    private bool facingRight = false;
    private bool isAttacking = false;

    void Start()
    {
        aggro = aggroRange.GetComponent<AggroController>();
        enemy = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

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
        if (isAttacking) return 0f;

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetReached = false;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetReached = true;
        }
    }

    public void freezePosition()
    {
        isAttacking = true;
    }

    public void unfreezePosition()
    {
        isAttacking = false;
    }
}
