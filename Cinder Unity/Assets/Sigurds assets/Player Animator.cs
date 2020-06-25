using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator myAnim;
     
    public void triggerINVFrames()
    {
        StartCoroutine(HurtBlinker());
    }

    IEnumerator HurtBlinker()
    {
        int spikeLayer = LayerMask.NameToLayer("Environment Trigger");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer);

        myAnim.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(3);

        Physics2D.IgnoreLayerCollision(spikeLayer, playerLayer, false);
        myAnim.SetLayerWeight(1, 0);

    }
}
