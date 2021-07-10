using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public int Damage;
    public GameObject ParticleHit;
    private void OnCollisionEnter(Collision collision)
    {
        bool isSpit = collision.gameObject.tag == gameObject.tag;
        if (!isSpit)
        {
            GameObject impact = Instantiate(ParticleHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(impact, 0.5f);
            collision.gameObject.SendMessage("PlayerApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
        }
        else Destroy(gameObject, 4);
    }
}
