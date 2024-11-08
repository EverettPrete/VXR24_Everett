using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Room4 : MonoBehaviour
{
    [SerializeField] private Animator Cell = null;
    [SerializeField] private string chooseanimation1 = "animationName";

   [SerializeField] private Animator Butcher = null;
   [SerializeField] private string chooseanimation2 = "animationName";

    [SerializeField] private Animator Butcherroll = null;
    [SerializeField] private string chooseanimation3 = "animationName";

    public float wait1;

    public float wait2;

    public AudioSource CellSlam;
    public AudioSource piano;
    public AudioSource door;
    private void OnTriggerEnter(Collider collision)
    {

      

        StartCoroutine(pause());

    }

    private IEnumerator pause()

    { yield return new WaitForSeconds(wait1);

        Cell.Play(chooseanimation1, 0, 0.0f);
        CellSlam.Play();
        Butcher.Play(chooseanimation2, 0, 0.0f);
        door.Play();
        yield return new WaitForSeconds(wait2);
        Butcherroll.Play(chooseanimation3, 0, 0.0f);
        piano.Play();
    }



}
