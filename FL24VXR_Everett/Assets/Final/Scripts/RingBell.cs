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
    
    public UnityEvent RingRing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            presser = other.gameObject;
            RingRing.Invoke();
          
}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
         
            
        }
    }
}
