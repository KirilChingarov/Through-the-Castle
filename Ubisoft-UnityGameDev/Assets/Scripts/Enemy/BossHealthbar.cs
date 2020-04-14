using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    public HealthBar bossHealthbar;
    public EnemyController bossController;

    void Start()
    {
        bossHealthbar.setMaxHealth(150);
    }

    void Update()
    {
        bossHealthbar.setHealth(bossController.getHealth());
    }
}
