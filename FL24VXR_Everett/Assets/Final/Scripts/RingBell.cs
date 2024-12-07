using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Events;

public class RingBell : MonoBehaviour
{
    GameObject presser;
    public GameObject button;

    public AudioClip Ding;
    public AudioSource AudioSource;
    

    public UnityEvent RingRing;

    public float OnEnterZLocation = 0.02f;
    public float OnExitZLocation = 0.04f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, OnEnterZLocation, 0);
            presser = other.gameObject;
            RingRing.Invoke();
          AudioSource.PlayOneShot(Ding);
}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, OnExitZLocation, 0);
         
            
        }
    }
}
