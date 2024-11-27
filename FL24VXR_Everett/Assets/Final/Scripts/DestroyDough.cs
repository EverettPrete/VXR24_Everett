using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyDough : MonoBehaviour
{
    public GameObject FlatDough;
    
    public GameObject NewPosition;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the box collider has the tag "DoughBall"
        if (other.CompareTag("DoughBall"))
        {
            // Destroy the object
            Destroy(other.gameObject);
           
            StartCoroutine(SpawnDoughPause());
        }
    }

    IEnumerator SpawnDoughPause()
    {

        yield return new WaitForSeconds(.55f);  // Change the delay as needed
        GameObject duplicate = Instantiate(FlatDough);
        duplicate.transform.position = NewPosition.transform.position;

    }
}
