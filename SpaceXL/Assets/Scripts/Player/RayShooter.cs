using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public float damage = 15;
    public float range = 12;
    public float fireRate = 1;
    public Transform bubblesSpawn;
    public GameObject shootEffect;
    public AudioClip audioClip;
    public AudioSource audioSource;

    public Camera cam;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(audioClip);
        GameObject impact = Instantiate(shootEffect, bubblesSpawn.position, Quaternion.Euler(-90,0,0));
        Destroy(impact, 7f);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range))
        {
            Debug.Log("Пиу я поппал !!!!!!!!!");
            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * damage);
        }
    }
}