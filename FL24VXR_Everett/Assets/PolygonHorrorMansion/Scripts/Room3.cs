using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour
{

    public float wait1 = 3;
    public float wait2 = 3;

    [SerializeField] private Animator creep = null;
    [SerializeField] private string chooseanimation1 = "animationName";

    [SerializeField] private Animator SecretDoor = null;
    [SerializeField] private string chooseanimation2 = "animationName";


    public AudioSource window;
    public AudioSource nuse;
    public AudioSource manscream;
    public AudioSource doorOpen;

    private void OnTriggerEnter(Collider collision)
    {
       
        manscream.Play();  
        window.Play();
        nuse.Stop();
        creep.Play(chooseanimation1, 0, 0.0f);
        
        StartCoroutine(stopAudio());


    }
    private IEnumerator stopAudio()
    {
        yield return new WaitForSeconds(wait1);
        window.Stop();
        yield return new WaitForSeconds(wait2);
        SecretDoor.Play(chooseanimation2, 0, 0.0f);
        doorOpen.Play();
    }
}
