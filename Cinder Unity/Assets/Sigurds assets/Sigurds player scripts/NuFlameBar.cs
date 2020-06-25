using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuFlameBar : MonoBehaviour
{
    PlayerAnimator myAnim;
    public Slider mainBar;
    public Slider part1;
    public Slider part2;
    public Slider part3;
    public Slider part4;

    public float speed1, speed2, speed3, speed4, speed5;

    public float flameBoostDuration = 2.0f;

    private float flameBoostEffect = 1.0f;

    private float currentFlame;

    public float invincibiletyFrames = 2.0f;

    public static NuFlameBar instance;

    //This is for the Flame bar destruction

    public GameObject destroyPart4;
    public GameObject destroyPart3;
    public GameObject destroyPart2;
    public GameObject destroyPart1;
    public GameObject destroyMain;

    private void Awake()
    {
        instance = this;
        currentFlame = 1500;

    }


    void Start()
    {
        

    }


    void Update()
    {
        mainBar.value = currentFlame;
        part4.value = currentFlame;
        part3.value = currentFlame;
        part2.value = currentFlame;
        part1.value = currentFlame;

        Debug.Log("FlameBoostEffect" + flameBoostEffect);

        if (currentFlame >= 0 && currentFlame <= 500)
        {
            currentFlame += Time.deltaTime * speed1 * flameBoostEffect;
        }
        else if (currentFlame > 500 && currentFlame <= 750)
        {
            currentFlame += Time.deltaTime * speed2 * flameBoostEffect;
        }
        else if (currentFlame > 750 && currentFlame <= 1000)
        {
            currentFlame += Time.deltaTime * speed3 * flameBoostEffect;
        }
        else if (currentFlame > 1000 && currentFlame <= 1250)
        {
            currentFlame += Time.deltaTime * speed4 * flameBoostEffect;
        }
        else if (currentFlame > 1250 && currentFlame <= 1500)
        {
            currentFlame += Time.deltaTime * speed5 * flameBoostEffect;
        }
    }

    public void flameBoostActive()
    {
        flameBoostEffect = 16.0f;
        Invoke("flameBoostUnActive", flameBoostDuration);
        Debug.Log("Do it!");
    }

    private void flameBoostUnActive()
    {
        flameBoostEffect = 1.0f;
    }

    public void UseFlame(int amount)
    {

        if (currentFlame - amount >= 0)
        {
            currentFlame -= amount;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnScript>().Respawn();
        }

    }

    public void DestroyPartAnimationCheck()
    {
        if(currentFlame < 0)
        {
            myAnim.triggerINVFrames();
        }
    }

    public IEnumerator  GetDestroyPart()
    {
        if (part4 == true)
        {
            Debug.Log("FIRST HIT");
            part4.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            //Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);

        }
        else if (part4 == false)
        {
            Debug.Log("SECOND HIT");
            part3.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }

        else if (part3 == false)
        {
            Debug.Log("THIRD HIT");
            part2.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }

        else if (part2 == false)
        {
            Debug.Log("FOURTH HIT");
            part1.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }
        else if (part1 == false)
        {
            Debug.Log("FINAL HIT");
            GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnScript>().Respawn();
        }
       // DestroyPart();
    }

    // IEnumerator DestroyPart()
    //{

        //int spikeLayer = LayerMask.NameToLayer("Environment Trigger");
        //int playerLayer = LayerMask.NameToLayer("Player");
        //Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer);



       /* if (part4 == true)
        {
            Debug.Log("FIRST HIT");
            part4.gameObject.SetActive(false); 
            yield return new WaitForSeconds(3);
            //Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);

        }
        else if (part4 == false)
        {
            Debug.Log("SECOND HIT");
            part3.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
           // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }

        else if (part3 == false)
        {
            Debug.Log("THIRD HIT");
            part2.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
           // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }

        else if (part2 == false)
        {
            Debug.Log("FOURTH HIT");
            part1.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
           // Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        }
       else if(part1 == false)
        {
            Debug.Log("FINAL HIT");
            GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnScript>().Respawn();
        }
    } */
}
