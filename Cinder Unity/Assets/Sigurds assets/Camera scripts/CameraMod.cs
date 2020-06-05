using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMod : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public int newFov;

    public float multiplier;

    public float endTime;

    private bool isLerping = false;

    private void Update()
    {
        if (isLerping)
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, newFov, Time.deltaTime * multiplier);
        }  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(vcam.m_Lens.FieldOfView == newFov)
            {
                return;
            } 
            isLerping = true;
            Invoke("EndLerp", endTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (vcam.m_Lens.FieldOfView == 60)
            {
                return;
            }
            newFov = 60;
            isLerping = true;
            Invoke("EndLerp", endTime);
        }
    }


    private void EndLerp()
    {
        isLerping = false;
        vcam.m_Lens.FieldOfView = newFov;
    }
}
