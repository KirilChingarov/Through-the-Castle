using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController
{
    private float health;
    private bool isDead = false;

    public CharacterController()
    {
        health = 10f;
    }

    public CharacterController(float health)
    {
        this.health = health;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            isDead = true;
        }
    }

    public bool isCharacterDead()
    {
        return isDead;
    }
}
