using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    public CounterTopCollider TheCounter;

    public bool PizzaIsOnCounter;
    public GameObject CounterTop;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == CounterTop)
        {
            PizzaIsOnCounter = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == CounterTop)
        {
            PizzaIsOnCounter = false;
        }
    }
    private void Update()
    {
        if (TheCounter.PizzaIsCorrect)
        {
            if (PizzaIsOnCounter)
            {
                TheCounter.PizzaIsCorrect = false;
                Destroy(transform.parent.gameObject);
              
            }
        }
    }
}
