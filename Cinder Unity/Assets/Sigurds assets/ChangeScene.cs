using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string newScene;

    public Image fadeToBlack;

    public bool playerHasEntered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHasEntered = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasEntered = false;
        }
    }

    private void Update()
    {
        if(playerHasEntered == true)
        if (Input.GetButtonDown("interact"))
        {
                fadeToBlack.DOFade(1, 4);
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Invoke("ChangeTheScene", 4);
        }


    }
    private void ChangeTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

   
}
