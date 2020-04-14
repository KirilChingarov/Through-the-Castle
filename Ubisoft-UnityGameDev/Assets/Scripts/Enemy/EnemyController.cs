using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth = 100f;
    CharacterHealth controller;
    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = new CharacterHealth(enemyHealth);
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isCharacterDead())
        {
            Die();
        }
    }

    public void takeDamage(float damage)
    {
        controller.takeDamage(damage);
        enemyAnimator.SetTrigger("isTakingDamage");
    }

    public float getHealth()
    {
        return controller.getHealth();
    }

    public bool isEnemyDead()
    {
        return controller.isCharacterDead();
    }

    void Die()
    {
        enemyAnimator.Play("Death");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<Collider2D>().enabled = false;
    }

    void DestroyEnemy()
    {
        Debug.Log(name + " died!");
        Destroy(gameObject);
    }
}
