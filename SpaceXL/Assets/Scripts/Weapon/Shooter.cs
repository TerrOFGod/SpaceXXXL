using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region Variables
    public float fireRate = 5;
    public int maxAmmo = 25;
    private int currentAmmo = 10;
    public Transform bubblesSpawn;
    public GameObject shootEffect;
    public AudioClip shootClip;
    public AudioClip ReloadingClip;
    public AudioSource audioSource;
    public GameObject Bullet;
    public int MaxTotalAmmo = 120;
    public int TotalAmmo = 100;
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    public AmmoBar Ammo;
    #endregion

    #region Callbacks
    private void Start()
    {
        Ammo.SetMaxAmmo(MaxTotalAmmo);
        Ammo.SetAmmo(TotalAmmo);
    }
    void Update()
    {
        if (isReloading) return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
        else if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    #endregion

    #region Private Methods
    void Shoot()
    {
        currentAmmo--;
        audioSource.PlayOneShot(shootClip);
        Instantiate(Bullet, bubblesSpawn.position, bubblesSpawn.rotation);
        GameObject MuzzleFlash = Instantiate(shootEffect, bubblesSpawn.position, Quaternion.Euler(-90, 0, 0));
        Destroy(MuzzleFlash, 7f);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        
        if (TotalAmmo > 0)
        {
            audioSource.PlayOneShot(ReloadingClip);
            yield return new WaitForSeconds(ReloadingClip.length);
            if (TotalAmmo < maxAmmo)
            {
                currentAmmo = TotalAmmo;
                TotalAmmo -= currentAmmo;
            }
            else
            {
                currentAmmo = maxAmmo;
                TotalAmmo -= maxAmmo;
            }
        }
        Ammo.SetAmmo(TotalAmmo);
        isReloading = false;
    }
    #endregion
}