using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCookingTracker : MonoBehaviour
{
    public Renderer CookTimer;
    public OvenButton OvenButton;

    public int heat;

    public AudioSource TimerDing;
    public AudioSource TimerTicking;

    public CookFood CookFood;
    public GameObject OvenCollider;
    public float CookScore;
    public bool PizzaInOven;

    public bool PizzaIsRaw = true;
    public bool PizzaIsCooked;
    public bool PizzaIsCrispy;

    public AudioSource Sizzling;

    public void Update()
    {
        if (CookScore >CookFood.OvenCookTime)
        {
            PizzaIsCooked = true;
            PizzaIsRaw = false;
            
            Renderer renderer = CookTimer.GetComponent<Renderer>();
            renderer.material.color = Color.green;
            Debug.Log("pizza is cooked");
            if (!TimerDing.isPlaying)
            {
                TimerDing.Play();
            }
        }
        if (CookScore > CookFood.OvenCookTime+5)
        {
            PizzaIsCrispy = true;
            PizzaIsCooked = false;
            Renderer renderer = CookTimer.GetComponent<Renderer>();
            renderer.material.color = Color.yellow;
            Debug.Log("pizza is cooked");
            if (!TimerDing.isPlaying)
            {
                TimerDing.Play();
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == OvenCollider && OvenButton.StoveIsOn)
        {
            PizzaInOven = true;
            if (PizzaInOven)
            {
                CookScore += 0.01f;
                if (!TimerTicking.isPlaying)
                {
                    TimerTicking.Play();
                }
            }


            if (!Sizzling.isPlaying)
            {
                Sizzling.Play();
            }
        }
        else if (!OvenButton.StoveIsOn) { 
        Sizzling.Stop();
        }
    }



    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == OvenCollider)
        {
            PizzaInOven = false;
          
            Renderer renderer = CookTimer.GetComponent<Renderer>();
            renderer.material.color = Color.black;
            Sizzling.Stop();
            TimerTicking.Stop();
        }
    }
}
