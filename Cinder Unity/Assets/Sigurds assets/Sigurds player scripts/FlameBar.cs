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
        flameBar.maxValue = maxFlame;
        flameBar.value = maxFlame;
    }

    public void UseFlame(int amount)
    {

        if(currentFlame - amount >= 0)
        {
            currentFlame -= amount;
            flameBar.value = currentFlame;


           regen = StartCoroutine(RegenFlame()); 
        }
       
      

        else
        {
            gameObject.GetComponent<RespawnScript>().Respawn();
        }


    }

    private IEnumerator RegenFlame()
    {
        yield return new WaitForSeconds(1);

        while(currentFlame < maxFlame)
        {
            currentFlame += maxFlame / 100;
            flameBar.value = currentFlame;
            yield return regenTick;

        }
        regen = null;
    }

}
