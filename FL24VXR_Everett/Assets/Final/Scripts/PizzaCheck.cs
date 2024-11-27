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

    public bool ShouldHaveCheese;
    public bool ShouldHavePeperoni;
    public bool ShouldHaveSauce;
    public bool ShouldHavePepers;

  

    public GameObject Ticket;
    public GameObject newPosition;

    public bool PrintTicket = false;
    public void Update()
    {
        if (PrintTicket)
        {
            MakeTicket();
            PrintTicket = false;
            GameObject duplicate = Instantiate(Ticket);
            duplicate.transform.position = newPosition.transform.position;


        }
    }
    void MakeTicket()
    {
        ShouldHaveCheese = Random.value > 0.5;
        ShouldHavePeperoni = Random.value > 0.5;
        ShouldHaveSauce = Random.value > 0.5;
        ShouldHavePepers = Random.value > 0.5;

        string ingredients = "";

        if (ShouldHaveSauce) {ingredients += "Pizza Sauce\n";    }

        if (ShouldHaveCheese) {ingredients += "Cheese\n";  }

        if (ShouldHavePeperoni) {ingredients += "Pepperoni\n";}

        if (ShouldHavePepers) {ingredients += "Peppers\n";}

        ingredientsList.text = ingredients;
    }
}
