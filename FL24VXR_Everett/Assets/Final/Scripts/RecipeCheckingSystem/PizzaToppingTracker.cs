using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaToppingTracker : MonoBehaviour
{

   

    public string CheeseTag = "BallCheese";
    public string PeperoniTag= "BallPepperoni";
    public string PeperTag= "BallPeper";
    public string SauceTag = "Spoon";
    public string OliveTag = "BallOlive";
    public string MushroomTag = "BallMushroom";
    public string RedOninonTag = "BallRedOnion";


    
    public PlaceDownSauce PlaceDownSauce;

    public bool HasCheese = false;
    public bool HasPeperoni = false;
    public bool HasPeper = false;
    public bool HasSauce = false;
    public bool HasOlive = false;
    public bool HasMushroom = false;
    public bool HasRedOnion = false;

   

    
        

    

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            Topping track = other.gameObject.GetComponent<Topping>();
            if (other.gameObject.name.Contains(CheeseTag) && track.OutOfBox == true)
            {
                HasCheese = true;
            }
            if (other.gameObject.name.Contains(PeperoniTag) && track.OutOfBox == true)
            {
                HasPeperoni = true;
            }
            if (other.gameObject.name.Contains(PeperTag) && track.OutOfBox == true)
            {
                HasPeper = true;
            }
            if (other.gameObject.name.Contains(OliveTag) && track.OutOfBox == true)
            {
                HasOlive = true;
            }
            if (other.gameObject.name.Contains(MushroomTag) && track.OutOfBox == true)
            {
                HasMushroom = true;
            }
            if (other.gameObject.name.Contains(RedOninonTag) && track.OutOfBox == true)
            {
                HasRedOnion = true;
            }
        }
        
        
        
        if (other.gameObject.CompareTag(SauceTag) && PlaceDownSauce.PickupSauce.SpoonHasSauce)
            {
                HasSauce = true;
            }

    }
}