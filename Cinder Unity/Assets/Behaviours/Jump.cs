using System.Collections;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{

    //[Range(1, 10)]
    public float jumpVelocity = 5;
    [Range(1,5)]
    public float fallMultiplier = 2.5f;
    [Range(1,5)]
    public float lowJumpMultiplier = 2f;

    public float maxFallVelocity = 5;

    public int extraJumpValue = 1;

    [HideInInspector]
    public int extraJumps;

    Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpRemember = 0;
    public float coyoteTime;

    //Wallslide info

    public float wallCheckDistance;
    public Transform wallCheck;
    private RaycastHit2D wallCheckHitRight;
    private RaycastHit2D wallCheckHitLeft;
    private bool isWallSliding = false;
    public float maxWallSlideVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
        jumpRemember = 0;
}

    void FixedUpdate()
    {
        //WallSlide start
        wallCheckHitRight = Physics2D.Raycast(wallCheck.position, wallCheck.right, wallCheckDistance, whatIsGround);
        wallCheckHitLeft = Physics2D.Raycast(wallCheck.position, -wallCheck.right, wallCheckDistance, whatIsGround);

        if (isWallSliding)
        {
            if(rb.velocity.x > -maxWallSlideVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxWallSlideVelocity);
            }
        }
        //WallSlide end
        

        if (rb.velocity.y < -maxFallVelocity)
        {
            Vector2 v = new Vector2(rb.velocity.x,-maxFallVelocity);
            rb.velocity = v;
        }
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        RaycastHit2D groundRay = Physics2D.Raycast(groundCheck.position, Vector2.down, checkRadius, whatIsGround);
       if(groundRay.collider != null)
        {
            isGrounded = true;
               
        }else
        {
            isGrounded = false;
        }
        Debug.DrawRay(groundCheck.position, new Vector2(0, -checkRadius), Color.cyan); 
        if(isGrounded)
        {
            jumpRemember = Time.time + coyoteTime;
        }
    }

   

    public void jump(bool jumpInput,bool jumpHold)
    {
        
        if (coyoteCheck())
        {
            extraJumps = extraJumpValue;
        }
        if (jumpInput && coyoteCheck())
        {
            rb.velocity = getJumpVector();
        }

        else if (jumpInput && extraJumps > 0)
        {
            rb.velocity = getJumpVector();
            extraJumps--;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpHold)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //THE WALL JUMP
        //if(isWallSliding && wallCheckHitRight && jumpInput)
        //{
        //    rb.AddForce(new Vector2(-jumpVelocity*10, jumpVelocity*3));
        //    Debug.Log("walljump right");
        //} 
        //else if(isWallSliding && wallCheckHitLeft && jumpInput)
        //{
        //    rb.AddForce(new Vector2(jumpVelocity*10, jumpVelocity*3));
        //    Debug.Log("walljump left");
        //} 
    }
    public void resetJumps()
    {
        extraJumps = extraJumpValue;
    }
    private Vector2 getJumpVector()
    {
        Vector2 jump = Vector2.up * jumpVelocity;
        jump.x = rb.velocity.x;
        return jump;
    }

    private bool coyoteCheck()
    {
        bool result = jumpRemember>Time.time;
        return result;
    }

    private void Update()
    {
        //check if wall sliding
        if (wallCheckHitRight && rb.velocity.y <= 0 && !isGrounded)
        {
            isWallSliding = true;
        }else if(wallCheckHitLeft && rb.velocity.y <= 0 && !isGrounded)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
}
