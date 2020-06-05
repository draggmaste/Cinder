using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //PlayerData player;
    //public int currentFlame => player.currentFlame;
    private GameObject useableBody;
    public followMovementDirection cameraTarget;
    bool spiritMode;
    public float spiritSpeedMultiplier;
    public Climbable climbingObject;

    bool inputOverride;
    int overrideFrames;
    float moveOverride;
    bool jumpOverride;

    #region public settings
    public int maxFlame = 200;
    public float checkRadius = 0.5f;
    #endregion

    #region controlReferences
    public GameObject mainBody;
    public GameObject controlObject;
    public Health health; 
    public Dash dash;
    public Jump jump;
    public HoldingItem heldItem;
    public Move move;
    public Climb climb;
    public WallSlide wallSlide;
    #endregion

    #region input variables

    bool jumpInput;
    bool jumpHold;
    bool dashInput;
    bool pickupInput;
    bool pickupHold;
    bool switchBodyInput;

    float moveInput = 0;
    float moveVerticalInput = 0;
    public LayerMask whatIsBody;
    #endregion

    void Awake()
    {
        resetInputs();
        if(ReferenceEquals(mainBody,controlObject)) spiritMode = true;
        else spiritMode = false;
    }
    void Start()
    {
        //player = new PlayerData(maxFlame);
    }

    void Update()
    {
        captureInput();
    }

    void FixedUpdate()
    {
        if(controlObject == null && mainBody != null)
        {
            switchBody(mainBody);
        }
        detectBody();
        controlPlayer();
        resetInputs();
    }

    private void controlPlayer()
    {
        if (climbingObject == null)
        {
            if (!inputOverride)
            {
                normalBehaviour();
            }
            else
            {
                
                
                if (jump != null) jump.jump(jumpOverride, jumpOverride);
                move.move(moveOverride);
                overrideFrames--;
                if(overrideFrames == 0)
                {
                    inputOverride = false;
                }
            }
        }
        else
        {
            climbingBehaviour();
        }
    }

    private void climbingBehaviour()
    {
        if (climbingObject.vertical)
        {
            climb.climb(moveVerticalInput, climbingObject.vertical);
        }
        else
        {
            climb.climb(moveInput, climbingObject.vertical);
        }

        if (jumpInput)
        {
            climbingObject.letGo();
            jump.jump(jumpInput, jumpHold);
        }
        jump.resetJumps();
    }

    private void normalBehaviour()
    {
        if (!wallSlide.getSlideState())
        {
            if (jump != null) jump.jump(jumpInput, jumpHold);
        }
        else
        {
            if (jumpInput)
            {
                float moveDir = 0;
                if (moveInput<0) moveDir = 1f;
                else moveDir = -1f;
                setInputOverride(wallSlide.wallJumpOverride,moveDir,true,true);
            }
        }
        if (heldItem != null)
        {
            if (pickupInput) heldItem.pickupOrDrop();
            if (pickupHold && heldItem != null) heldItem.useItem();
        }
        if (useableBody != null)
        {
            if (switchBodyInput && !ReferenceEquals(useableBody, controlObject)) switchBody(useableBody);
        }
        move.move(moveInput);
        if (move.vertical)
        {
            move.moveVertical(moveVerticalInput);
        }
        if (dash != null) dash.dash(dashInput);
    }

    private void setInputOverride(int frames, float moveInput, bool jump, bool resetJumps)
    {
        if(resetJumps) this.jump.resetJumps();
        inputOverride = true;
        overrideFrames = frames;
        moveOverride = moveInput;
        jumpOverride = jump;
    }
    

    #region input handling
    private void captureInput()
    {
        if (!pickupInput) pickupInput = Input.GetButtonDown("pickup");
        if (!pickupHold) pickupHold = Input.GetButtonDown("useItem");
        if (!jumpInput) jumpInput = Input.GetButtonDown("Jump");
        if (!jumpHold) jumpHold = Input.GetButton("Jump");
        if (!dashInput) dashInput = Input.GetKey(KeyCode.LeftShift);
        if (!switchBodyInput) switchBodyInput = Input.GetButtonDown("useBody");
        moveInput = Input.GetAxisRaw("Horizontal");
        moveVerticalInput = Input.GetAxisRaw("Vertical");
        if(spiritMode && dashInput)
        {
            moveInput *= spiritSpeedMultiplier;
            moveVerticalInput *= spiritSpeedMultiplier;
        }
    }

    private void resetInputs()
    {
        pickupInput = false;
        pickupHold = false;
        jumpInput = false;
        jumpHold = false;
        dashInput = false;
        switchBodyInput = false;
    }
    #endregion

    #region switchBody

    bool detectBody()
    {
        bool result = false;
        Collider2D newBody = Physics2D.OverlapCircle(controlObject.transform.position,checkRadius,whatIsBody);
        if (newBody == null)
        {
            useableBody = mainBody;
        }
        else if (!ReferenceEquals(newBody.transform.parent.gameObject, controlObject))
        {
            useableBody = newBody.transform.parent.gameObject;
            result = true;
        }
        else
        {
            useableBody = mainBody;
        }
        return result;
    }

    void switchBody(GameObject newBody)
    {
        if(controlObject != null) controlObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (!ReferenceEquals(newBody, mainBody))
        {
            mainBody.transform.parent = newBody.transform;
            mainBody.transform.localPosition = Vector3.zero;
            mainBody.GetComponent<Rigidbody2D>().simulated = false;
            spiritMode = false;
        }
        else
        {
            spiritMode = true;
            mainBody.GetComponent<Rigidbody2D>().simulated = true;
            mainBody.transform.parent = controlObject.transform.parent;
        }
        controlObject = newBody;
        cameraTarget.rb = newBody.GetComponent<Rigidbody2D>();
        
        if(controlObject.GetComponent<Health>() != null)
        {
            health = controlObject.GetComponent<Health>();
        }
        else
        {
            health = null;
        }
        if(controlObject.GetComponent<Dash>() != null)
        {
            dash = controlObject.GetComponent<Dash>();
        }
        else
        {
            dash = null;
        }
        if(controlObject.GetComponent<Jump>() != null)
        {
            jump = controlObject.GetComponent<Jump>();
        }
        else
        {
            jump = null;
        }
        if (controlObject.GetComponent<HoldingItem>() != null)
        {
            heldItem = controlObject.GetComponent<HoldingItem>();
        }
        else
        {
            heldItem = null;
        }
        if (controlObject.GetComponent<Move>() != null)
        {
            move = controlObject.GetComponent<Move>();
        }
        else
        {
            move = null;
        }
        useableBody = null;
    }
    #endregion
}
