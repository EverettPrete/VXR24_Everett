using Microsoft.Win32.SafeHandles;
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
    

    public GameObject NewSpawnPosition;
   
 

    public float playbackSpeed = 1.0f; // Custom playback speed

    [SerializeField] private Animator CrusherAnimation = null;
    [SerializeField] private string chooseanimation = "animationName";
   
    [SerializeField] private Animator GearAnimator1 = null;
    [SerializeField] private string chooseanimation1 = "animationName";
    
    [SerializeField] private Animator GearAnimator2 = null;
    [SerializeField] private string chooseanimation2 = "animationName";
    
    [SerializeField] private Animator GearAnimator3 = null;
    [SerializeField] private string chooseanimation3 = "animationName";
    
    [SerializeField] private Animator GearAnimator4 = null;
    [SerializeField] private string chooseanimation4 = "animationName";

    public AudioSource ClickDownSound;
    public AudioSource ClickUpSound;
    public AudioSource clunk;
    public AudioSource Chain;
    public AudioSource Click;


    public Vector3 NewPosition;
    public GameObject FlatDough;
    public GameObject BallDough;
    public Collider Collider;
   
  

    // Start is called before the first frame update
  

 

    // Trigger when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the correct object (e.g., VR controller or another object)
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
           
            onPress.Invoke();


            ClickDownSound.Play();

            
            StartCoroutine(ClangSound());

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


            ClickUpSound.Play();





        }
    }

    public void PlayAnimation()
    {
     
     
    }

   public IEnumerator ClangSound()
    {
        yield return new WaitForSeconds(.3f);
        Click.Play();

        yield return new WaitForSeconds(.3f);
        CrusherAnimation.Play(chooseanimation, 0, 0.0f);




        GearAnimator1.Play(chooseanimation1, 0, 0.0f);
        GearAnimator2.Play(chooseanimation2, 0, 0.0f);
        GearAnimator3.Play(chooseanimation3, 0, 0.0f);
        GearAnimator4.Play(chooseanimation4, 0, 0.0f);


        yield return new WaitForSeconds(0.3f);
        clunk.Play();
        yield return new WaitForSeconds(.4f);
        Chain.Play();




    }

}
