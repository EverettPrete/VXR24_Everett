using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerSFX1 : MonoBehaviour
{
    // Reference to the GameObject that has the AudioSource
 
    
    public AudioSource lightsSound2;
    public AudioSource rocksound;
    public AudioSource windowshatter;
   
    public AudioSource radio;

    public Light[] lights2;  // Array to hold multiple lights if needed
    public float flickerDuration2 = 1f;  // Total time the lights will flicker
    public float flickerSpeed2 = 0.1f;  // Time between flickers

   [SerializeField] private Animator rock = null;
   [SerializeField] private string chooseanimation = "animationName"; 


    private void OnTriggerEnter(Collider collision)
    {

        // Check if the audio source is set and play the sound
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FlickerAndTurnOff2());
           
            radio.Play();  
           
            windowshatter.Play();   
            rock.Play(chooseanimation, 0, 0.0f);
            lightsSound2.Play();
            rocksound.Play();  
            Debug.Log("yippeee");

            
           


        }
    }



    private IEnumerator FlickerAndTurnOff2()
    {
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration2)
        {
            // Toggle lights on/off
            bool isOn = Random.value > 0.5f;
            foreach (Light light in lights2)
            {
                light.enabled = isOn;
            }

            // Wait for the next flicker
            yield return new WaitForSeconds(flickerSpeed2);
            elapsedTime += flickerSpeed2;
        }

        // Ensure lights are off after flickering
        foreach (Light light in lights2)
        {
            light.enabled = false;
        }
    }
}