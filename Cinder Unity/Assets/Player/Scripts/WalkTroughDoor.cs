using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTroughDoor : MonoBehaviour
{
    public Transform warp;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }



    public void teleport()
    {
        transform.position = warp.position;
    }
    
}
