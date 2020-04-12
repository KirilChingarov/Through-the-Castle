using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    private bool inRange = false;
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            player = collision.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            player = null;
        }
    }

    public bool isInRange()
    {
        return inRange;
    }

    public void Attack(float damage)
    {
        if (player != null)
        {
            player.takeDamage(damage);
        }
    }
}
