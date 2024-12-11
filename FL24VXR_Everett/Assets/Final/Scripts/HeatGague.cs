using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatGague : MonoBehaviour
{
    public GameObject Dial;
    public float DialSpinSpeed = 10;
    public float DialOffset;
    public float Dial0;
    private float flickerValue;

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("Cooked"))
       {
            PizzaCookingTracker track = other.gameObject.GetComponent<PizzaCookingTracker>();
            
            Dial.transform.localEulerAngles = new Vector3(DialOffset+flickerValue + track.CookScore * DialSpinSpeed,0,0);


        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cooked"))
        {
            Dial.transform.localEulerAngles = new Vector3(Dial0 + flickerValue, 0,0);
        }
    }
  

    void Start()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true) 
        {
            flickerValue = Random.Range(-1f, 1f);  
            yield return new WaitForSeconds(0.1f); 
        }
    }
}
