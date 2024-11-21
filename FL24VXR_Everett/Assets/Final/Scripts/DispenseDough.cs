using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DispenseDough : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public GameObject Dough;
    public Vector3 newPosition;



    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            Debug.Log("ButtonIsCicked");
        
    }

    private void OnTriggerExit(Collider other)
    {
        
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
            onRelease.Invoke();
            isPressed = false;  
            Debug.Log("ButtonIsCicked");
        
     
    }

    public void SpawnDough()
    {
        GameObject duplicate = Instantiate(Dough);
        duplicate.transform.position = newPosition;
    }
}
