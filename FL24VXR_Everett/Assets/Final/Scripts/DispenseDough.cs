using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DispenseDough : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    
    public GameObject Dough;
    public GameObject newPosition;

    public float playbackSpeed = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            presser = other.gameObject;
            onPress.Invoke();
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
            onRelease.Invoke();
           
          
            
                StartCoroutine(SpawnDoughPause());
            
        }
    }

   
    IEnumerator SpawnDoughPause()
    {
        // Wait for 2 seconds before spawning the dough
        yield return new WaitForSeconds(1.25f);  // Change the delay as needed
        GameObject duplicate = Instantiate(Dough);
        duplicate.transform.position = newPosition.transform.position;
    
    }
}
