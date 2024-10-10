using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggersfx : MonoBehaviour
{
    public AudioSource playsound;
    public AudioClip quiet;

    private void OnTriggerEnter(Collider other)
    {
        playsound.Play();
        playsound.PlayOneShot(quiet);
    }
}