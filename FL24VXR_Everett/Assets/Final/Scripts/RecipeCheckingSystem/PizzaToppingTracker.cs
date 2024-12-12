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

                AddFlatTooping(other, track);
            }
            if (other.gameObject.name.Contains(PeperoniTag) && track.OutOfBox == true)
            {
                HasPeperoni = true;

                AddFlatTooping(other, track);
            }
            if (other.gameObject.name.Contains(PeperTag) && track.OutOfBox == true)
            {
                HasPeper = true;

                AddFlatTooping(other, track);
            }
            if (other.gameObject.name.Contains(OliveTag) && track.OutOfBox == true)
            {
                HasOlive = true;

                AddFlatTooping(other, track);
            }
            if (other.gameObject.name.Contains(MushroomTag) && track.OutOfBox == true)
            {
                HasMushroom = true;

                AddFlatTooping(other, track);
            }
            if (other.gameObject.name.Contains(RedOninonTag) && track.OutOfBox == true)
            {
                HasRedOnion = true;

                AddFlatTooping(other, track);
            }
        }
        
        
        
        if (other.gameObject.CompareTag(SauceTag) && PlaceDownSauce.PickupSauce.SpoonHasSauce)
            {
                HasSauce = true;
            }

    }

    private void AddFlatTooping(Collider other, Topping track)
    {

        GameObject duplicate = Instantiate(track.FlatToppings, transform.position, transform.rotation);
        duplicate.transform.SetParent(transform);
        duplicate.transform.localPosition = new Vector3(0, 0, track.offset);

/*
        Vector3 targetPosition = track.TargetObject.transform.position;
        GameObject replicate = Instantiate(track.ToppingsPrefab, targetPosition, Quaternion.identity);
        if (track.WasDuplicatedByTimer == false)
        {

            track.DuplicateTopping();
            track.WasDuplicatedByCollider = true;
            Debug.Log("was duplicated by collider");
        }
*/
        other.gameObject.SetActive(false);
        
    }

  
}