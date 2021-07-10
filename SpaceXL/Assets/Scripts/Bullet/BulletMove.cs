using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Damage = 20;
    public GameObject ParticleHit;
    //public int StartSpeed;
    //Vector3 previousStep;
    //float startTime;
    public int Speed;
    Vector3 lastPos;
    
    void Awake()
    {
        lastPos = transform.position;
        DestroyNow();
        //GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * StartSpeed);
        //previousStep = gameObject.transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        RaycastHit hit;
        if(Physics.Linecast(lastPos,transform.position,out hit))
        {
            print(hit.transform.name);
            SendDamage(hit.transform.gameObject);
            GameObject impact =Instantiate(ParticleHit, lastPos, Quaternion.identity);
            Destroy(gameObject);
            Destroy(impact, 0.5f);
        }
        lastPos = transform.position;
    }

    void DestroyNow()
    {
        Destroy(gameObject,3);
    }

    void SendDamage(GameObject hit)
    {
        hit.SendMessage("ApplyDamage",Damage, SendMessageOptions.DontRequireReceiver);
    }

}
