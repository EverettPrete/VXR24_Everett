using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;

public class PizzaCheck : MonoBehaviour
{
    // this script goes on the physical ticket
    public TextMeshProUGUI ingredientsList;
    public TicketScript TicketScript;


    [SerializeField] private Animator Cell = null;
    [SerializeField] private string chooseanimation1 = "animationName";



    public bool ShouldHaveCheese;
    public bool ShouldHavePeperoni;
    public bool ShouldHaveSauce;
    public bool ShouldHavePepers;
    public bool ShouldHaveOlives;
    public bool ShouldHaveMushrooms;
    public bool ShouldHaveRedOnions;

    public bool Raw = false;
    public bool Cooked = false;
    public bool Crispy = false;
   
    public float RawCheck;
    public float CookedCheck;
    public float CrispyCheck;

    public AudioSource PrinterSound;

    public int TicketNumber = -1;

    public GameObject Ticket;
    public GameObject newPosition;

    public bool PrintTicket = false;
    public bool StartingTicket = true;
    public bool StartingBone = false;

    public bool TicketIsActive;
    private void Start()
    {
       TicketIsActive = true;
        if (StartingTicket)
        {
            StartingBone = true;
        }
        else StartingBone = false;

     Rigidbody rb = GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
          
        TicketNumber += 1;
        MakeTicket();
        if (StartingTicket == false) { StartCoroutine(TicketSpawner()); }

       
           
           
           
        
        

       
    }


    public void Update()
    {
        if (PrintTicket)
        {
            MakeTicket();
        }
        TicketIsActive = TicketScript.IsActive;
    }
    public void MakeTicket()
    {
       
     

        ShouldHaveCheese = Random.value > 0.05;
        ShouldHavePeperoni = Random.value > 0.5;
        ShouldHaveSauce = Random.value > 0.05;
        ShouldHavePepers = Random.value > 0.5;
        ShouldHaveOlives = Random.value > 0.5;
        ShouldHaveMushrooms = Random.value > 0.5;
        ShouldHaveRedOnions = Random.value > 0.5;

        RawCheck = Random.Range(0.00f, 10.00f);
        CookedCheck = Random.Range(0.00f, 12.00f);
        CrispyCheck = Random.Range(0.00f, 7.00f);

        if ((RawCheck > CookedCheck) && (RawCheck > CrispyCheck))    {Raw = true;}
        else {Raw = false;}
        if ((CookedCheck > RawCheck) && (CookedCheck > CrispyCheck)) {Cooked = true; }
        else {Cooked = false;}
        if ((CrispyCheck > CookedCheck) && (CrispyCheck > RawCheck)) {Crispy = true; }
        else { Crispy = false;}

        string ingredients = "";
        ingredients += "Prehistoric Pizza\n";
        ingredients += " Ticket  #  " + TicketNumber ;
        ingredients += "\n";
        ingredients += " w*** PICK UP *** \n";
        ingredients += "PHONE NUMBER : Na \n";
        ingredients += "----------------\n";
        ingredients += "14 '' LG \n ";
        ingredients += "--------- \n";
        ingredients += "Pizza With: \n";

        if (ShouldHaveSauce) {ingredients += " Pizza Sauce\n";    }

        if (ShouldHaveCheese) {ingredients += " Cheese\n";  }

        if (ShouldHavePeperoni) {ingredients += " Pepperoni\n";}

        if (ShouldHavePepers) {ingredients += " Peppers\n";}

        if (ShouldHaveOlives) { ingredients += " Olives\n"; }

        if (ShouldHaveMushrooms) { ingredients += " Mushroom\n"; }

        if (ShouldHaveRedOnions) { ingredients += " RedOnions\n"; }
        ingredients += "----------------\n";


        if (Raw) { ingredients += "  Raw __ "; }
        if (Cooked) { ingredients += "  Cooked []_ "; }
        if (Crispy) { ingredients += "  Crispy [][] "; }

        ingredientsList.text = ingredients;

        
        PrintTicket = false;
      

    }

    IEnumerator TicketSpawner()
    {

        
            Debug.Log("ticket is going to print soon");
            yield return new WaitForSeconds (30-TicketNumber);
       StartCoroutine(TicketDuplicator());
           

        
    }
    public void MakeFirstTicket()
    {
        StartingTicket = false;
        StartCoroutine(TicketDuplicator());
    }

   IEnumerator TicketDuplicator()
    {
      
        Cell.Play(chooseanimation1, 0, 0.0f);
        PrinterSound.Play();
        yield return new WaitForSeconds(1.8f);
        GameObject duplicate = Instantiate(Ticket);
        duplicate.transform.position = newPosition.transform.position;

    }

}
