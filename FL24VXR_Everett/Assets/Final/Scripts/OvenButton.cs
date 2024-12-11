using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenButton : MonoBehaviour
{
    public AudioSource ClickDownSound;
    public AudioSource ClickUpSound;

    public Light ovenlight1;
    public Light ovenlight2;
    public Light ovenlight3;

    public GameObject targetObject; // Assign the GameObject in the Inspector
    public Color color1 = Color.black; // First color
    public Color color2 = Color.red; // Second color

    public bool StoveIsOn = false; // Tracks which color is currently active

    public GameObject button;

   private void Update()
    {
        
            ovenlight1.enabled = StoveIsOn;
            ovenlight2.enabled = StoveIsOn;
            ovenlight3.enabled = StoveIsOn;
            
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);


            ToggleOven();
            ClickDownSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
            ClickUpSound.Play();



           

        }



    }
    public void ToggleOven()
    {
        // Toggle the bool
        StoveIsOn = !StoveIsOn;

        // Get the Renderer component of the target object
        Renderer renderer = targetObject.GetComponent<Renderer>();

        


        if (renderer != null)
        {
            // Change color based on the current bool value
            renderer.material.color = StoveIsOn ? color2 : color1;
        }


    }





}
