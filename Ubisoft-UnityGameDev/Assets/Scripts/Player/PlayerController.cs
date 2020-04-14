using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterHealth controller;
    public float playerHealth = 100f;

    public HealthBar healthBar;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = new CharacterHealth(playerHealth);
        healthBar.setMaxHealth(playerHealth);
        playerAnimator = GetComponent<Animator>();
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
        healthBar.setHealth(getHealth());
        playerAnimator.SetTrigger("isTakingDamage");
    }

    public float getHealth()
    {
        return controller.getHealth();
    }

    void Die()
    {
        playerAnimator.Play("Death");
    }

    void DestroyPlayer()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }
}
