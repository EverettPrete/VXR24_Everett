using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CounterTopCollider : MonoBehaviour
{
  

    public bool IsPizzaOnCounter;
    public bool IsTicketOnCounter;

    public bool PizzaIsCorrect = false;
    [Tooltip("Whats on the pizza")]
    public bool PizzaHazCheese;
    public bool PizzaHazPepperoni;
    public bool PizzaHazSauce;
    public bool PizzaHazPeppers;
    public bool PizzaHazOlives;
    public bool PizzaHazMushrooms;
    public bool PizzaHazRedOnions;
    [Tooltip("How cooked?")]
    public bool PizzaIsRawYay;
    public bool PizzaIsCookedYay;
    public bool PizzaIsCrispyYay;

    [Tooltip("Whats on the ticket")]
    public bool TicketHazCheese;
    public bool TicketHazPepperoni;
    public bool TicketHazSauce;
    public bool TicketHazPeppers;
    public bool TicketHazOlives;
    public bool TicketHazMushrooms;
    public bool TicketHazRedOnions;

    public bool TicketRaw;
    public bool TicketCooked;
    public bool TicketCrispy;
    [Tooltip("Has This ticket been completed already?")]
    public bool TicketIsActive;


    public int Score;
    //When the pizza or ticket enters
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dough"))
        {
            
            IsPizzaOnCounter = true;
            PizzaToppingTracker tracked = other.gameObject.GetComponent<PizzaToppingTracker>();

            PizzaHazPeppers = tracked.HasPeper;
            PizzaHazCheese = tracked.HasCheese;
             PizzaHazPepperoni = tracked.HasPeperoni;
             PizzaHazSauce = tracked.HasSauce;
            PizzaHazOlives = tracked.HasOlive;
            PizzaHazMushrooms = tracked.HasMushroom;
            PizzaHazRedOnions = tracked.HasRedOnion;

           

        }
        if (other.gameObject.CompareTag("Cooked"))
        {
            PizzaCookingTracker iscooked = other.gameObject.GetComponent<PizzaCookingTracker>();
            PizzaIsRawYay = iscooked.PizzaIsRaw;
            PizzaIsCookedYay = iscooked.PizzaIsCooked;
            PizzaIsCrispyYay = iscooked.PizzaIsCrispy;


        }
            if (other.gameObject.CompareTag("Ticket"))
        {
            IsTicketOnCounter = true;
            PizzaCheck track = other.gameObject.GetComponent<PizzaCheck>();
             
            TicketHazCheese = track.ShouldHaveCheese;
             TicketHazPepperoni = track.ShouldHavePeperoni;
             TicketHazSauce = track.ShouldHaveSauce;
             TicketHazPeppers = track.ShouldHavePepers;
            TicketHazOlives = track.ShouldHaveOlives ;
            TicketHazMushrooms = track.ShouldHaveMushrooms;
            TicketHazRedOnions = track.ShouldHaveRedOnions;
            TicketIsActive = track.TicketIsActive;

            TicketRaw = track.Raw;
            TicketCooked = track.Cooked;
            TicketCrispy = track.Crispy;
        }
    }

    //When the ticket or pizza leaves
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dough"))
        {
            IsPizzaOnCounter = false;
           ClearPizza();
        }

        if (other.gameObject.CompareTag("Ticket"))
        {
            IsTicketOnCounter = false;
            ClearTicket(); 
        }
        if (other.gameObject.CompareTag("Cooked"))
        {

            PizzaIsCookedYay = false;

        }
    }

    public void CompareTicketToPizza()
    {

        if (PizzaHazCheese == TicketHazCheese &&
            PizzaHazPepperoni == TicketHazPepperoni &&
            PizzaHazSauce == TicketHazSauce &&
            PizzaHazPeppers == TicketHazPeppers &&
            PizzaHazOlives == TicketHazOlives &&
            PizzaHazMushrooms == TicketHazMushrooms &&
            PizzaHazRedOnions == TicketHazRedOnions &&

            TicketRaw == PizzaIsRawYay &&
            TicketCooked == PizzaIsCookedYay &&
            TicketCrispy == PizzaIsCrispyYay &&

            TicketIsActive == true &&
            IsTicketOnCounter && IsPizzaOnCounter)
        {
            PizzaIsCorrect = true;
            Debug.Log("Pizza Is Correct ;)");

            Score++;
        }
        else { Debug.Log("Pizza is wrong "); }
    }

   public void ClearTicket()
    {
        TicketHazCheese = false;
        TicketHazPepperoni = false;
        TicketHazSauce = false;
        TicketHazPeppers = false;
        TicketHazOlives = false;
        TicketHazMushrooms = false;
        TicketHazRedOnions = false;  

        IsTicketOnCounter = false;
        TicketIsActive = false;
    }
    public void ClearPizza()
    {
        PizzaHazCheese = false;
        PizzaHazPepperoni = false;
        PizzaHazSauce = false;
        PizzaHazPeppers = false;
        PizzaHazOlives = false;
        PizzaHazMushrooms = false;
        PizzaHazRedOnions = false;

        IsPizzaOnCounter = false;
    }

    
}
