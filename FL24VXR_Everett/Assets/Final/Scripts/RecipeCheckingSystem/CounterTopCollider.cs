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
    
    public bool PizzaHazCheese;
    public bool PizzaHazPepperoni;
    public bool PizzaHazSauce;
    public bool PizzaHazPeppers;

    public bool TicketHazCheese;
    public bool TicketHazPepperoni;
    public bool TicketHazSauce;
    public bool TicketHazPeppers;

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
            
        }

        if (other.gameObject.CompareTag("Ticket"))
        {
            IsTicketOnCounter = true;
            PizzaCheck track = other.gameObject.GetComponent<PizzaCheck>();
             
            TicketHazCheese = track.ShouldHaveCheese;
             TicketHazPepperoni = track.ShouldHavePeperoni;
             TicketHazSauce = track.ShouldHaveSauce;
             TicketHazPeppers = track.ShouldHavePepers;
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
    }

    public void CompareTicketToPizza()
    {
        if (PizzaHazCheese == TicketHazCheese &&
            PizzaHazPepperoni == TicketHazPepperoni &&
            PizzaHazSauce == TicketHazSauce &&
            PizzaHazPeppers == TicketHazPeppers &&
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
        IsTicketOnCounter = false;
    }
    public void ClearPizza()
    {
        PizzaHazCheese = false;
        PizzaHazPepperoni = false;
        PizzaHazSauce = false;
        PizzaHazPeppers = false;
        IsPizzaOnCounter = false;
    }

}
