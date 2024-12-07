using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketScript : MonoBehaviour
{
    public CounterTopCollider TheCounter;
    
    public bool TicketIsOnCounter;
    public GameObject CounterTop;

    public bool IsActive = true;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == CounterTop)
        {
            TicketIsOnCounter = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == CounterTop)
        {
            TicketIsOnCounter = false;
        }
    }

    private void Update()
    {

        if (TheCounter.PizzaIsCorrect)
        {
            if (TicketIsOnCounter)
            {
                IsActive = false;
               
            }
        }
    }

}
