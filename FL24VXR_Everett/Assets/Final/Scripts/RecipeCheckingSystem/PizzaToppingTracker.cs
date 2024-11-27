using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaToppingTracker : MonoBehaviour
{


    public Topping canSpawnCheese;
    public Topping canSpawnPeperoni;
    public Topping canSpawnPepers;


    public string CheeseTag = "Cheese";
    public string PeperoniTag= "Peperoni";
    public string PeperTag= "pepers";
    public string SauceTag = "Spoon";

    public PlaceDownSauce PlaceDownSauce;

    public bool HasCheese = false;
    public bool HasPeperoni = false;
    public bool HasPeper = false;
    public bool HasSauce = false;

   

    
        

    

void OnTriggerStay(Collider other)
    {

            if (other.gameObject.name.Contains(CheeseTag) && canSpawnCheese.canSpawn == false)
            {
                HasCheese = true;
            }
            if (other.gameObject.name.Contains(PeperoniTag) && canSpawnPeperoni.canSpawn == false)
            {
                HasPeperoni = true;
            }
            if (other.gameObject.name.Contains(PeperTag) && canSpawnPepers.canSpawn == false)
            {
                HasPeper = true;
            }
            if (other.gameObject.CompareTag(SauceTag) && PlaceDownSauce.PickupSauce.SpoonHasSauce)
            {
                HasSauce = true;
            }

    }
}