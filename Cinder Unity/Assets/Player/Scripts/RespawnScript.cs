using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Transform startPosition;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Respawn()
    {
        transform.position = startPosition.position;
    }
}
