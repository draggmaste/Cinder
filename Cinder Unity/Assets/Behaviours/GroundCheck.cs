using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform groundCheck;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Awake()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D groundRay = Physics2D.Raycast(groundCheck.position, Vector2.down, checkRadius, whatIsGround);
        if (groundRay.collider != null)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(groundCheck.position, new Vector2(0, -checkRadius), Color.cyan);
    }
}
