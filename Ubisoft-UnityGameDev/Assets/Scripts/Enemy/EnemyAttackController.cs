using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackCooldown = 5f;
    private float nextAttack = 0f;

    private Animator enemyAnimator;

    public GameObject attackRange;
    private EnemyAttackRange attack;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        attack = attackRange.GetComponent<EnemyAttackRange>();
    }

    void Update()
    {
        if (attack.isInRange() && nextAttack <= Time.time)
        {
            enemyAnimator.SetTrigger("Attack");
            nextAttack = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        if (attack.isInRange())
        {
            attack.Attack(attackDamage);
        }
    }
}
