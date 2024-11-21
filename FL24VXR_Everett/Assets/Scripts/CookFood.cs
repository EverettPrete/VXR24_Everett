using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookFood : MonoBehaviour
{
    public ButtonDown ButtonDown;

    public float heat = 1f;

    // Dictionary to track cookScore for each food object
    private Dictionary<GameObject, float> cookScores = new Dictionary<GameObject, float>();

  
    public Renderer targetRenderer;
    public Color newColor = Color.green;
    public Color originalColor = Color.black;

    public Color targetColor = Color.black;
    public TMP_Text TimerTime;
    public float TotalCookTime = 5;


  


    private void OnTriggerStay(Collider other)
    {
        
        if (ButtonDown.burnerOn)
        {
           

            // Check if the object has the tag "Food"
            if (other.CompareTag("Food"))
            {
                // Get or initialize cookScore for this object
                if (!cookScores.ContainsKey(other.gameObject))
                {
                    cookScores[other.gameObject] = 0f;
                }

                // Increment the cookScore
                cookScores[other.gameObject] += heat * Time.deltaTime;

                // Check if the object is fully cooked
                if (cookScores[other.gameObject] > TotalCookTime)
                {
                    
                        targetRenderer.material.color = newColor;
                    
                  
                }
                else { targetRenderer.material.color = originalColor; }

                
                Renderer objectRenderer = other.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    Color currentColor = objectRenderer.material.color;
                    Color newColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * heat/(TotalCookTime*2));
                    objectRenderer.material.color = newColor;
                }
                else
                {
                    Debug.LogWarning($"{other.name} has the tag 'Food' but no Renderer component!");
                }

               if (TotalCookTime < 0)
                {
                    TimerTime.text = "" + (TotalCookTime - (int)cookScores[other.gameObject]);
                }
                
                   
                
                
                    
                
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (cookScores.ContainsKey(other.gameObject))
        {
            cookScores.Remove(other.gameObject);
        }
    }
}
