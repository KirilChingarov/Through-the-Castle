using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public float attackDamage = 25f;
    public float attackCooldown = 2f;
    private float nextAttack = 0f;

    private Animator playerAnimator;

    public GameObject attackRange;
    private PlayerAttackRange attack;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        attack = attackRange.GetComponent<PlayerAttackRange>();
    }

    void Update()
    {
        if (Input.GetButtonDown("LeftMouseButton") && nextAttack <= Time.time)
        {
            playerAnimator.SetTrigger("Attack");
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
