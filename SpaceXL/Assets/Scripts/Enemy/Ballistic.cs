using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{
    public Transform SpawnTransform;
    public Transform TargetTransform;

    public float Angle;

    public float g = Physics.gravity.y;

    public GameObject Bullet;
    

    void Start()
    {
        
    }

    void Update()
    {
        //transform.LookAt(TargetTransform);
        SpawnTransform.localEulerAngles = new Vector3(-Angle, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleInRad = Angle * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRad) * x) * Mathf.Pow(Mathf.Cos(angleInRad),2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity= SpawnTransform.forward*v;
    }
}
