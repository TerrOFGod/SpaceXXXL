using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivate : MonoBehaviour
{
    public GameObject Spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Spawner.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
