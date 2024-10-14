using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //cached ref
    [SerializeField] PlayerHealth playerTarget;

    //param
    [SerializeField] float damage = 25f;

    public void AttackHitAnimEvent()
    {
        if (playerTarget == null) return;
        playerTarget.TakeDamage(damage);
    }
}
