using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFollow : MonoBehaviour
{
    public float speed;

    public AudioClip soundEffect;
    private EffectsPlayer theAM;

    public GameObject  disable;

    public Transform target;

    private void Start()
    {
        theAM = FindObjectOfType<EffectsPlayer>();
    }





    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            gameObject.SetActive(false);
            theAM.FirePickUpNow(soundEffect);
            //here we want something to tell our bigger circle colider, that when the player has entered it,
            //the object should fly towards the players position no matter if the player moves or what.
            Invoke("Following", 0);
        }
    }

    private void Following()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


    }
}
