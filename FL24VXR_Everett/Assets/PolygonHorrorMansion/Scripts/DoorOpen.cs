using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : MonoBehaviour
{

    public KeyPickup KeyPickup;

   

    public AudioSource doorLocked;
    public AudioSource doorOpen;

    [SerializeField] private Animator leftdoor = null;
    [SerializeField] private string chooseanimation1 = "animationName";
    [SerializeField] private Animator rightdoor = null;
    [SerializeField] private string chooseanimation2 = "animationName";

    private void OnTriggerEnter(Collider collision)
    {

        // Check if the audio source is set and play the sound
        if (collision.CompareTag("Player"))
        {
            if (KeyPickup.haskey == false)
            {
                doorLocked.Play();
                Debug.Log(KeyPickup.haskey);
            }
            else 
            {
                doorOpen.Play();
                leftdoor.Play(chooseanimation1, 0, 0.0f);
                rightdoor.Play(chooseanimation2, 0, 0.0f);
            }
            

        }
    }

}
