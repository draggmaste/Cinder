using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Collider2D touchingItem;
    private float originalClimbSpeed;

    public Transform world;
    public LayerMask whatIsPickup;
    public Transform checkPosition;
    public float checkRadius;

    private void Start()
    {
        originalClimbSpeed = GetComponent<Climb>().climbSpeed;
    }

    public void dropItem(HeldItem item)
    {
        item.transform.parent = world;
        Rigidbody2D rb = item.transform.GetComponent<Rigidbody2D>();
        rb.simulated = true;
        GetComponent<Jump>().extraJumpValue = 1;
        GetComponent<Climb>().climbSpeed = originalClimbSpeed;
    }

    public HeldItem pickupItem(Transform holdPos)
    {
        touchingItem = Physics2D.OverlapCircle(checkPosition.position, checkRadius, whatIsPickup);
        if (touchingItem != null)
        {
            touchingItem.transform.parent = holdPos.transform;
            touchingItem.transform.localPosition = holdPos.localPosition;
            Rigidbody2D rb = touchingItem.GetComponent<Rigidbody2D>();
            rb.simulated = false;
            GetComponent<Jump>().extraJumpValue = 0;
            GetComponent<Climb>().climbSpeed = 0;
            return touchingItem.GetComponent<HeldItem>();
        }
        return null;
    }
}
