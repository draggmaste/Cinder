using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class RespawnScript : MonoBehaviour
{
    public Transform startPosition;

    [SerializeField]
    private string CheckPoint;

    [SerializeField]
    private string NoCheckPoint;

    public bool checkPoint;
    public bool hasDied = false;

    public Image fadeToBlack;
    private void Start()
    {
        checkPoint = false;
       
    }

 

    public void Respawn()
    {
     if(checkPoint == true)
        {

            SceneManager.LoadScene(CheckPoint);
        }
     
        
     else if(checkPoint == false)
        {

            SceneManager.LoadScene(NoCheckPoint);
        }
     
    }

    public void ChekPointGet()
    {
        checkPoint = true;
    }

   

    



}
