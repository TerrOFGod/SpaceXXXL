using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public HealthBar healthBar;
    public PlayerHealth health;
    private int damage = 35;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("PlayerApplyDamage", damage);
            healthBar.SetHealth(health.HealthPoint);
        }
    }
}
