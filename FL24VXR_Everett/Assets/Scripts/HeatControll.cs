using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HeatControll : MonoBehaviour
{
    public CookFood CookFood;
    public TMP_Text buttontext;

    private bool isButtonPressed = false; 

    public void increaseHeat()
    {
       
        if (isButtonPressed) return;
   
        isButtonPressed = true;

        CookFood.heat += 1;

        buttontext.text = "Heat: " + CookFood.heat.ToString();
     
        Debug.Log(CookFood.heat);
        Debug.Log("Function called by: " + this.gameObject.name);

        StartCoroutine(ResetButtonPress());
    }

    public void decreaseHeat()
    {
       
        if (isButtonPressed) return;

        isButtonPressed = true;

        CookFood.heat -= 1;
      buttontext.text = "Heat: " + CookFood.heat.ToString();
   
        Debug.Log(CookFood.heat);
        Debug.Log("Function called by: " + this.gameObject.name);
    
        if (buttontext == null)
        {
            Debug.Log("No Text");
        }
  
        StartCoroutine(ResetButtonPress());
    }

    private IEnumerator ResetButtonPress()
    {
           yield return new WaitForSeconds(0.1f);
  
        isButtonPressed = false;
    }
}
