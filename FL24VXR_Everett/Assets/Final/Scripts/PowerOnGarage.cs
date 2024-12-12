using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerOnGarage : MonoBehaviour
{
    public UnityEvent StartGarage;
    public AudioSource PowerUp;
    bool Starting = false;
    public GameObject mainlight;

    public AudioSource LightFlickerSound;
    public AudioSource MixerStart;
    public AudioSource BoxOfMeldies;


    public Light targetLight; // The light to flicker
    public float minIntensity = 0f; // Minimum light intensity
    public float maxIntensity = 1f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // Speed of the flicker
    public bool randomize = true; // Randomize flicker intensity or use a fixed pattern

    private float nextFlickerTime = 0f;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == ("Cell")&& Starting == false)
        {
            StartGarage.Invoke();
            PowerUp.Play();
            Starting = true;
            Destroy(other.gameObject);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            mainlight.SetActive(true);
            TurnLightOn();
            LightFlickerSound.Stop();
            MixerStart.Play();
            BoxOfMeldies.volume = 1;
        }
    }
    
    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
            
        }
    }

    void Update()
    {
      if(Starting == false)
        {
            if (Time.time >= nextFlickerTime)
            {
                FlickerLight();
                nextFlickerTime = Time.time + flickerSpeed;
            }
        }
      
    }

    void FlickerLight()
    {
       if (Starting == false)
        {
            if (randomize)
            {
                targetLight.intensity = Random.Range(minIntensity, maxIntensity);
            }
            else
            {
                targetLight.enabled = !targetLight.enabled;
            }
        }
        
    }

    public void TurnLightOn()
    {
    
            targetLight.enabled = true;
            targetLight.intensity = maxIntensity; // Set to maximum intensity
        
    }
}



