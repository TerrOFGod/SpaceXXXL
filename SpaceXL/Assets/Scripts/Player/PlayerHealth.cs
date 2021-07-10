using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int HealthPoint;

    public HealthBar healthBar;
    private void Start()
    {
        HealthPoint = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    void PlayerApplyDamage(int damage)
    {
        HealthPoint -= damage;
        healthBar.SetHealth(HealthPoint);
        if (HealthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
