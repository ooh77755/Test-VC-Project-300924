using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCam;

    float zoomIn = 20f;
    float zoomOut = 60f;

    bool zoomToggle = false;

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(1))
        {
            if(!zoomToggle)
            {
                zoomToggle = true;
                fpsCam.fieldOfView = zoomIn;
            }

            else if(zoomToggle)
            {
                zoomToggle = false;
                fpsCam.fieldOfView = zoomOut;
            }
        }
    }
}
