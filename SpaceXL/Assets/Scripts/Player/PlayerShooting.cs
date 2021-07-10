using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletSpawn;
    void Update()
    {
        if(Input.GetMouseButton(0))
        Instantiate(Bullet,BulletSpawn.position, BulletSpawn.rotation);
    }
}
