using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DispenseDough : MonoBehaviour
{
    public GameObject button;

    public UnityEvent onRelease;

    public AudioSource ClickDownSound;
    public AudioSource ClickUpSound;
    public AudioSource Mixer;
    public AudioSource DoughComingOut;
    public AudioSource SplatSound;


    [SerializeField] private Animator Cell = null;
    [SerializeField] private string chooseanimation1 = "animationName";


    public GameObject Dough;
    public GameObject newPosition;

    public float playbackSpeed = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
           
          
            ClickDownSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Button") || other.CompareTag("FingerTip"))
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
          
            ClickUpSound.Play();


            StartCoroutine(SpawnDoughPause());
            
        }
    }

   
    IEnumerator SpawnDoughPause()
    {
        Mixer.Play();
        Cell.Play(chooseanimation1, 0, 0.0f);
        yield return new WaitForSeconds(2f);
        onRelease.Invoke();

        // Wait for 2 seconds before spawning the dough
        DoughComingOut.Play();
        yield return new WaitForSeconds(0.3f);
        
        SplatSound.Play();

        yield return new WaitForSeconds(1.25f);  // Change the delay as needed
        GameObject duplicate = Instantiate(Dough);
        duplicate.transform.position = newPosition.transform.position;
    
    }
}
