using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractComplex : MonoBehaviour
{
    public GameObject text;
   // private bool interact = false;

    void Start()
    {
        text.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }

    /*void Update()
    {
        if (!interact) interact = Input.GetButtonDown("interact");
    }

    void FixedUpdate()
    {
        if (interact)
        {

            text.SetActive(false);
        }
        else
        {

            text.SetActive(true);
        } */




    }
