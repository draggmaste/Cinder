using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    
    public float movementSpeed = 0.1f;
    public bool vertical;
    Rigidbody2D rb;
    public SpriteRenderer interact;

    [HideInInspector]
    public bool facingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        
    }

    public void move(float moveInput)
    {
        Vector2 newSpeed = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        rb.velocity = newSpeed;
        if (moveInput < 0 && facingRight)
        {
            Vector3 v = rb.transform.localScale;
            v.x *= -1;
            rb.transform.localScale = v;
            facingRight = false;
            interact.flipX = true;
        }
        else if (moveInput > 0 && !facingRight)
        {
            Vector3 v = rb.transform.localScale;
            v.x *= -1;
            rb.transform.localScale = v;
            facingRight = true;
            interact.flipX = false;
        }
    }

    public void moveVertical(float moveInput)
    {
        Vector2 newSpeed = new Vector2(rb.velocity.x,moveInput * movementSpeed);
        rb.velocity = newSpeed;
    }
}
