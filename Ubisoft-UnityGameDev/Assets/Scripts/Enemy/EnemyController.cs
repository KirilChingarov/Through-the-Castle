using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth = 100f;
    CharacterController controller;
    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = new CharacterController(enemyHealth);
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isCharacterDead())
        {
            Die();
        }
        /*else
        {

        }*/
    }

    public void takeDamage(float damage)
    {
        controller.takeDamage(damage);
        enemyAnimator.SetTrigger("isTakingDamage");
    }

    void Die()
    {
        enemyAnimator.Play("Death");
        Debug.Log(name + " died!");
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
