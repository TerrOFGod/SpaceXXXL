using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public PlayerHealth Health;
    private int HealthCount = 30;
    public HealthBar HealthBar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Health.HealthPoint += HealthCount;
            if (Health.HealthPoint>Health.MaxHealth)
            {
               Health.HealthPoint = Health.MaxHealth;
            }
            HealthBar.SetHealth(Health.HealthPoint);
            Destroy(gameObject);
        }
    }
}
