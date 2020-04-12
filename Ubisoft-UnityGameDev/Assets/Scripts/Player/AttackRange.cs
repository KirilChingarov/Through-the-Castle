using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private bool inRange = false;
    private EnemyController enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            inRange = true;
            enemy = collision.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            inRange = false;
            enemy = null;
        }
    }

    public bool isInRange()
    {
        return inRange;
    }

    public void Attack(float damage)
    {
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
    }
}
