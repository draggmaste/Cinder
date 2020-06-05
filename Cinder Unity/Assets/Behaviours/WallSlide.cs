using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(GroundCheck))]
public class WallSlide : MonoBehaviour
{
    public Rigidbody2D rb;
    public GroundCheck groundCheck;

    public float wallCheckDistance;
    public Transform wallCheck;
    private RaycastHit2D wallCheckHitRight;
    private RaycastHit2D wallCheckHitLeft;
    private bool isWallSliding = false;
    public float maxWallSlideVelocity;
    private bool right, left;
    public int wallJumpOverride;

    private LayerMask whatIsGround => groundCheck.whatIsGround;
    private bool isGrounded => groundCheck.isGrounded;
    // Start is called before the first frame update
    void Awake()
    {
        right = false;
        left = false;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wallCheckHitRight = Physics2D.Raycast(wallCheck.position, wallCheck.right, wallCheckDistance, whatIsGround);
        wallCheckHitLeft = Physics2D.Raycast(wallCheck.position, -wallCheck.right, wallCheckDistance, whatIsGround);
        updateWallslideState();
        wallSlide();
    }

    private void updateWallslideState()
    {
        if (wallCheckHitRight && rb.velocity.y <= 0 && !isGrounded)
        {
            isWallSliding = true;
        }
        else if (wallCheckHitLeft && rb.velocity.y <= 0 && !isGrounded)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void setDirection(bool right, bool left)
    {
        this.right = right;
        this.left = left;
    }

    private void wallSlide()
    {
        if (isWallSliding)
        {
            if (rb.velocity.x > -maxWallSlideVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxWallSlideVelocity);
            }
        }
    }

    public bool getRight()
    {
        return right;
    }

    public bool getLeft()
    {
        return left;
    }

    public bool getSlideState()
    {
        return isWallSliding;
    }
}
