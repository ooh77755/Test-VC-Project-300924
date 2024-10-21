using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] float cooldownTime = 0.5f;

    bool canShoot = true;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if(ammo.GetAmmoAmount(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammo.ReduceAmmo(ammoType);
        }
        
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    private void ProcessRaycast()
    {

        RaycastHit somethingWeHit;

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out somethingWeHit, raycastRange))
        {
            CreateHitEffect(somethingWeHit);
            EnemyHealth enemyTarget = somethingWeHit.transform.GetComponent<EnemyHealth>();
            if (enemyTarget == null) { return; }
            enemyTarget.TakeDamage(damage);
            
        }
        else { return; }
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
