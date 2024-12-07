using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variablesandoperators : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Variables

        int x = 0;
        float y = 2.5f;
       
     

        //arithmetic operators
        
         x = 10;        
         y = x - y * x / y;

        //assignment operators
        //comparison operators
        //logical operators
      

        
        //increment decrement operators
        for (int i = 0; i < x; i++)
        {
            y--;
        }
        //dot operators
        Console.WriteLine("sup dawg");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
