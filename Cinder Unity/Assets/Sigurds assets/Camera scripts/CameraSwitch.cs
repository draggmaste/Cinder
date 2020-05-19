using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera newCam;
    public Camera oldCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(newCam.enabled == false)
        {
            oldCam.enabled = false;
            newCam.enabled = true;
        }
    }
}
