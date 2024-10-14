using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;

    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 10f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRaycast();
        PlayMuzzleFlash();
    }

    private void ProcessRaycast()
    {

        RaycastHit somethingWeHit;

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out somethingWeHit, raycastRange))
        {
            CreateHitEffect(somethingWeHit);
            EnemyHealth enemyTarget = somethingWeHit.transform.GetComponent<EnemyHealth>();
            enemyTarget.TakeDamage(damage);

        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateHitEffect(RaycastHit somethingWeHit)
    {
        GameObject impact = Instantiate(hitVFX, somethingWeHit.point, Quaternion.identity);
        Destroy(impact, 0.1f);
    }
}
