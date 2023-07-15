using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera cam;
    
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
    /*
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(hit.point);
            Debug.Log("transform " + hit.point);
        }
        */
    }
}
