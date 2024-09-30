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

    private void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(target.position, transform.position);

        if(distanceToPlayer <= aggroRange)
        {
            nMA.SetDestination(target.transform.position);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
