using System.Collections.Generic;
using UnityEngine;

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
                if (cookScores[other.gameObject] > 5)
                {
                    if (targetRenderer != null)
                    {
                        targetRenderer.material.color = newColor;
                    }
                  
                }
                else { targetRenderer.material.color = originalColor; }

                // Smoothly interpolate the color of the object
                Renderer objectRenderer = other.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    Color currentColor = objectRenderer.material.color;
                    Color newColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * heat/8);
                    objectRenderer.material.color = newColor;
                }
                else
                {
                    Debug.LogWarning($"{other.name} has the tag 'Food' but no Renderer component!");
                }
            }
            Debug.Log(cookScores[other.gameObject]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the object from the dictionary when it exits the trigger
        if (cookScores.ContainsKey(other.gameObject))
        {
            cookScores.Remove(other.gameObject);
        }
    }
}
