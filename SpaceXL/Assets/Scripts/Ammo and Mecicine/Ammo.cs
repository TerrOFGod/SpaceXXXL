using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Shooter shooter;
    private int AmmoCount = 20;
    public AmmoBar AmmoBar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shooter.TotalAmmo += AmmoCount;
            if (shooter.TotalAmmo > shooter.MaxTotalAmmo)
            {
                shooter.TotalAmmo = shooter.MaxTotalAmmo;
            }
            AmmoBar.SetAmmo(shooter.TotalAmmo);
            Destroy(gameObject);
        }
    }
}
