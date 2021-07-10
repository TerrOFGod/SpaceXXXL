using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GrenadierAI : MonoBehaviour
{
    #region Variables
    public float BallisticsAngle;
    private GameObject player;
    public float sightRange = 50;
    public float attackRange;
    public float meleeAttackRange = 10;
    NavMeshAgent nav;
    Animator animator;
    public Transform SpitSpawn;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public bool playerInMeleeAttackRange;
    public bool alreadyAttacked;
    public float TimeBetweenAttacks;
    public GameObject projectile;
    public LayerMask playerMask, groundMask;


    Vector3 fromTo;
    Vector3 fromToXZ;
    #endregion

    #region Callbacks
    void Start()
    {
        player = GameObject.Find("Player");
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 lookAtPLayer = player.transform.position - transform.position;
        Vector3 lookAtPLayerXZ = new Vector3(lookAtPLayer.x, 0, lookAtPLayer.z);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        playerInMeleeAttackRange = Physics.CheckSphere(transform.position, meleeAttackRange, playerMask);
        if (playerInMeleeAttackRange && playerInAttackRange && playerInSightRange)
        {
            animator.ResetTrigger("Walk");
            transform.rotation = Quaternion.LookRotation(lookAtPLayerXZ, Vector3.up);
            MeleeAttack();
        }
        else
        if (playerInAttackRange && playerInSightRange)
        {
            animator.ResetTrigger("Walk");
            fromTo = player.transform.position - SpitSpawn.transform.position;
            fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
            transform.rotation = Quaternion.LookRotation(lookAtPLayerXZ, Vector3.up);
            SpitSpawn.localEulerAngles = new Vector3(-BallisticsAngle, 0f, 0f);
            AttackPlayer();
            Debug.Log("Attack");
        }
        else if (!playerInAttackRange && playerInSightRange)
        {
            ChasePlayer();
            Debug.Log("Chase");
        }
    }
    #endregion

    #region Private Methods
    //Chasing
    void ChasePlayer()
    {
        animator.ResetTrigger("Idle");
        nav.enabled = true;
        nav.SetDestination(player.transform.position);
        animator.SetTrigger("Walk");
    }

    //Atacking
    void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            animator.SetTrigger("RangeAttack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        nav.enabled = false;
    }

    void MeleeAttack()
    {
        if (!alreadyAttacked)
        {
            animator.SetTrigger("MeleeAttack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }

        nav.enabled = false;
    }

    void Shot()
    {
        #region Ballistics
        //Vector3 fromTo = player.transform.position - SpitSpawn.transform.position;
        // Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleInRad = BallisticsAngle * Mathf.PI / 180;

        float v2 = (Physics.gravity.y * x * x) / (2 * (y - Mathf.Tan(angleInRad) * x) * Mathf.Pow(Mathf.Cos(angleInRad), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));
        #endregion

        GameObject newBullet = Instantiate(projectile, SpitSpawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = SpitSpawn.forward * v;
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
    #endregion

}
