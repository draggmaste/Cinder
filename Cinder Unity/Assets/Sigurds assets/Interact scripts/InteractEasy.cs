﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEasy : MonoBehaviour
{

    public GameObject text;
  
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



}
