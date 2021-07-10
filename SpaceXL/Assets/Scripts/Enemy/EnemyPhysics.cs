using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    CharacterController chController;
    void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    void Update()
    {
        chController.Move(Physics.gravity * Time.deltaTime);
    }
}
