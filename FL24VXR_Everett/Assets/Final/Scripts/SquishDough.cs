using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.Interaction.Toolkit;

public class SquishDough : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public GameObject NewSpawnPosition;
   
 

    public float playbackSpeed = 1.0f; // Custom playback speed

    [SerializeField] private Animator Cell = null;
    [SerializeField] private string chooseanimation = "animationName";

    public Vector3 NewPosition;
    public GameObject FlatDough;
    public GameObject BallDough;
    public Collider Collider;
    bool doughloaded = false;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    


    // Trigger when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the correct object (e.g., VR controller or another object)
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            


            PlayAnimation();
            

        }
    }

    // Trigger when something exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the correct object is the one that exited
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
            onRelease.Invoke();
            isPressed = false;
           



          

        }
    }

    public void PlayAnimation()
    {
        Cell.Play(chooseanimation, 0, 0.0f);
    }
   
}
