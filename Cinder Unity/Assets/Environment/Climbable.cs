using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : InteractableTrigger
{
    public PlayerControler player;
    private Rigidbody2D rb;
    public bool vertical;
    private bool playerInRange;
    private bool interact;
    private float gravModMemory = 0;

    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    void Awake()
    {
        rb = player.controlObject.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("Player Detected!");
            text.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
<<<<<<< HEAD
            text.SetActive(false);
=======
            Debug.Log("Player Left!");
>>>>>>> d63fd431a76aeece984e97f393b1d702741e1e53
        }
    }

    void Update()
    {
        if (!interact) interact = Input.GetButtonDown("interact");
    }

    void FixedUpdate()
    {
        if (playerInRange && interact)
        {
            setActiveState(!getActiveState());
            if(getActiveState())
            {
                player.climbingObject = this;
                gravModMemory = rb.gravityScale;
                rb.gravityScale = 0;
                text.SetActive(false);
            }
            else
            {
                player.climbingObject = null;
                rb.gravityScale = gravModMemory;
                text.SetActive(true);
            }
        }
        if (!playerInRange && getActiveState())
        {
            setActiveState(!getActiveState());
            player.climbingObject = null;
            rb.gravityScale = gravModMemory;
            
        }
        interact = false;
    }

    public void letGo()
    {
        setActiveState(false);
        player.climbingObject = null;
        rb.gravityScale = gravModMemory;
    }
}
