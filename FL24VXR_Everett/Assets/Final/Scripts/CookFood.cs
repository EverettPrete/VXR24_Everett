using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookFood : MonoBehaviour
{
 
   
    public OvenButton OvenButton;
    public int OvenCookTime = 7;



    private void OnTriggerStay(Collider other)
    {
       if(OvenButton.StoveIsOn)
        if (other.CompareTag("Food")  || other.CompareTag("Dough") || other.gameObject.name.Contains("(willburn)") )
        {
                Debug.Log("The oven is on and cooking that food");
                Renderer renderer = other.GetComponent<Renderer>();
            renderer.material.color = Color.Lerp(renderer.material.color, Color.black, Time.deltaTime/OvenCookTime);
            
        }

    }
}
