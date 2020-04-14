using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth
{
    private float health;
    private bool isDead = false;

    public CharacterHealth()
    {
        health = 10f;
    }

    public CharacterHealth(float health)
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

    public float getHealth()
    {
        return health;
    }

    public bool isCharacterDead()
    {
        return isDead;
    }
}
