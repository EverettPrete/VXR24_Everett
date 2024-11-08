using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public AudioSource key;
    public bool haskey = false;
    
    

    private void OnTriggerEnter(Collider collision)
    {

        // Check if the audio source is set and play the sound
        if (collision.CompareTag("Player"))
        {
           
            key.Play(); 
            haskey = true;
        }
    }

    
}
