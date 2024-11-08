using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    // Reference to the GameObject that has the AudioSource
 
    public AudioSource thunder;
    public AudioSource lightsSound;

    public Light[] lights;  // Array to hold multiple lights if needed
    public float flickerDuration = 1f;  // Total time the lights will flicker
    public float flickerSpeed = 0.1f;  // Time between flickers





    private void OnTriggerEnter(Collider collision)
    {

        // Check if the audio source is set and play the sound
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FlickerAndTurnOff());

            thunder.volume = 0.0f;
            lightsSound.Play();
            Debug.Log("yippeee");


        }
    }



    private IEnumerator FlickerAndTurnOff()
    {
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration)
        {
            // Toggle lights on/off
            bool isOn = Random.value > 0.5f;
            foreach (Light light in lights)
            {
                light.enabled = isOn;
            }

            // Wait for the next flicker
            yield return new WaitForSeconds(flickerSpeed);
            elapsedTime += flickerSpeed;
        }

        // Ensure lights are off after flickering
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}