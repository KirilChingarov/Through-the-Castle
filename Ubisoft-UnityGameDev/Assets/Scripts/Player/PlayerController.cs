using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float playerHealth = 100f;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = new CharacterController(playerHealth);
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
        playerAnimator.SetTrigger("isTakingDamage");
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
