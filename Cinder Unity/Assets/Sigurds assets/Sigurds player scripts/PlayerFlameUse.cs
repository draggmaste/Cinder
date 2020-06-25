using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFlameUse : MonoBehaviour
{
    public static PlayerFlameUse instance;
    public int flameBoostTimer;

    public Text flameBoostCounter;

    

    

    

    private void Start()
    {
        instance = this;
        flameBoostTimer = 0;
    }


    void Update()
    {
       // flameBoostCounter = flameBoostTimer;

        if (Input.GetButtonDown("Jump"))
        {
            NuFlameBar.instance.UseFlame(60);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            NuFlameBar.instance.UseFlame(80);
        }
       /* else if (gameObject.GetComponent<Climb>().isClimbing())
        {
            FlameBar.instance.UseFlame(50)
        } */
        
    }

    public void setRegenTimer()
    {
        while(flameBoostTimer == 9)
        {
            flameBoostTimer += 1;
        }

        while(flameBoostTimer < 10)
        {
           

            flameBoostTimer =+ 2;
            
        }

        while(flameBoostTimer == 0)
        {
            GameObject.FindGameObjectWithTag("FlameBar").GetComponent<FlameBar>().flameBoostUnActive();
        } 
    }

    //We should put enemy types down hhere for now

   public void spikeDamage()
    {

        GameObject.FindGameObjectWithTag("FlameBar").GetComponent<NuFlameBar>().GetDestroyPart();
        NuFlameBar.instance.UseFlame(200);
        //GameObject.FindGameObjectWithTag("FlameBar").GetComponent<NuFlameBar>().DestroyPartAnimationCheck();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpikeTrap spikeTrap = collision.collider.GetComponent<SpikeTrap>();
        if(spikeTrap != null)
        {
            spikeDamage ();
        }
    }
}
