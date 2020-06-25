using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{

    public AudioSource flamePickUpSound;


    
    public void FirePickUpNow(AudioClip effect)
    {
        flamePickUpSound.clip = effect;
        flamePickUpSound.Play();
        Invoke("StopFireSound", 2);

    }

    private void StopFireSound(AudioClip effect)
    {
        flamePickUpSound.Stop();
    }
}
