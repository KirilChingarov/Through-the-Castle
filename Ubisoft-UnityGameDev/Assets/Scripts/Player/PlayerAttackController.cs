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
    private AttackRange attack;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
        attack = attackRange.GetComponent<AttackRange>();
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
