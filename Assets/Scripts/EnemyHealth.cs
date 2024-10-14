using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hP = 50f;

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        hP -= damage;
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
