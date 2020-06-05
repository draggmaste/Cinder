using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlameUse : MonoBehaviour
{
    

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            FlameBar.instance.UseFlame(120);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            FlameBar.instance.UseFlame(160);
        }
       /* else if (gameObject.GetComponent<Climb>().isClimbing())
        {
            FlameBar.instance.UseFlame(50)
        } */
        
    }
}
