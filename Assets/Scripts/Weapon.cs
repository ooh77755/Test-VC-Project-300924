using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;

    [SerializeField] float raycastRange = 100f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit somethingWeHit;
        Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out somethingWeHit, raycastRange);
        print("we hit" + somethingWeHit.transform.name);
    }
}
