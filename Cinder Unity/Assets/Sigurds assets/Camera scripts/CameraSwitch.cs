using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraSwitch : MonoBehaviour
{
    public Camera newCam;
    public Camera oldCam;

    public Image fadeToBlack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(newCam.enabled == false)
        {
            fadeToBlack.DOFade(1, 0);
            oldCam.enabled = false;
            newCam.enabled = true;
            Invoke("fadeIn", 2);
            
        }
    }

    private void fadeIn()
    {
        fadeToBlack.DOFade(0, 1);
    }
}
