using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePickUp : MonoBehaviour
{

    public GameObject flameCounter;
    public GameObject vanish;








    //This is for the little box colider that gives you Flame regen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameObject.FindGameObjectWithTag("FlameBar").GetComponent<NuFlameBar>().flameBoostActive();

            gameObject.SetActive(true);

            gameObject.SetActive(false);



            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFlameUse>().setRegenTimer();


        }
    }

    




}
