using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class FlameBar : MonoBehaviour
{
    

    public Slider flameBar;
    public Slider part1;
    public Slider part2;
    public Slider part3;
    public Slider part4;

    public bool flameBoost = false;

    public void SetFlame(int flame)
    {
        flameBar.value = flame;
        part1.value = flame;
        part2.value = flame;
        part3.value = flame;
        part4.value = flame;
    }


    private int partOneFlame = 250;
    private int partTwoFlame = 250;
    private int partThreeFlame = 250;
    private int partFourFlame = 250;
    private int mainFlame = 500;
    private int maxFlame;


    private int currentFlame;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static FlameBar instance;

    private void Awake()
    {
        instance = this;

    }



    void Start()
    {
        maxFlame = partOneFlame + partTwoFlame + partThreeFlame + partFourFlame + mainFlame;

        

        currentFlame = maxFlame;
       // flameBar.maxValue = maxFlame;
        //flameBar.value = maxFlame;
    }

    private void Update()
    {
        flameBar.value = currentFlame;
        part4.value = currentFlame;
        part3.value = currentFlame;
        part2.value = currentFlame;
        part1.value = currentFlame;
    }

    public void UseFlame(int amount)
    {

        if(currentFlame - amount >= 0)
        {
            currentFlame -= amount;
          /*  flameBar.value = currentFlame;
            part4.value = currentFlame;
            part3.value = currentFlame;
            part2.value = currentFlame;
            part1.value = currentFlame; */

            Debug.Log("PrintOutFlame" + currentFlame);



           regen = StartCoroutine(RegenFlame()); 
        }
       
      

        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnScript>().Respawn();

      
        }


    }

    public void flameBoostActive()
    {
        flameBoost = true;
    }

    public void flameBoostUnActive()
    {
        flameBoost = false;
    }

    private IEnumerator RegenFlame()
    {
       

        

        
        while (currentFlame > 1250)
        {
            currentFlame += maxFlame / 1250;

            yield return regenTick;

        }

        while (currentFlame > 1000 && currentFlame < 1250)
        {
            currentFlame += maxFlame / 1000;

            yield return regenTick;
        }

        while (currentFlame > 750 && currentFlame < 1000)
        {
            currentFlame += maxFlame / 800;

            yield return regenTick;
        }

        while (currentFlame > 500 && currentFlame < 750)
        {
            currentFlame += maxFlame / 700;

            yield return regenTick;
        }

        while (currentFlame > 0 && currentFlame < 500)
        {
            currentFlame += maxFlame / 500;

            yield return regenTick;
        }
     

       
        regen = null;

        
    }


}
