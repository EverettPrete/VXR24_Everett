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
        string w = "dog";
        bool hot = false;

        //arithmetic operators
        
         x = 10;        
         y = x - y * x / y;

        //assignment operators
        //comparison operators
        //logical operators
        if (y % x != 0 && x>5 || y<= 15)
        {
            hot = true;
        }

        if (!!hot)
        {
            w = "hotdog";
        }
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
