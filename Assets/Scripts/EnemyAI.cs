using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //cached refs
    [SerializeField] Transform target;
    NavMeshAgent nMA;

    //parameters
    [SerializeField] float aggroRange = 5f;
    float distanceToPlayer;
    float turnSpeed = 500f;

    //states
    bool isAggro = false;

    private void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(target.position, transform.position);

        if (distanceToPlayer <= aggroRange)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            EngagingPlayerWhenAggroed();
        }
    }

    private void EngagingPlayerWhenAggroed()
    {
        RotateToFacePlayer();

        if (distanceToPlayer >= nMA.stoppingDistance)
        {
            ChasePlayer();
        }

        if (distanceToPlayer <= nMA.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    void RotateToFacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion myCurrentRotation = transform.rotation;
        Quaternion myDesiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        Quaternion.Slerp(myCurrentRotation, myDesiredRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackPlayer()
    {

    }

    private void ChasePlayer()
    {
        nMA.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    
}
