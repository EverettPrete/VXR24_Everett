using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketKinematicController : MonoBehaviour
{
    public string ItemNameContains = "";
    public Rigidbody RigidTicket;
    public string hand1 = "";
    public string hand2 = "";

    public bool sticky = false;
    private void Start()
    {
        sticky = false;
        if (RigidTicket == null)
        {
            RigidTicket = GetComponent<Rigidbody>();
            if (RigidTicket == null)
            {
                Debug.LogError("RigidTicket not found or assigned!");
            }
        }
    }

    private void Update()
    {
       
        
       if (!sticky)
        {
            RigidTicket.isKinematic = false;
        }
        if (sticky)
        {
            RigidTicket.isKinematic = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == ItemNameContains)
        {
            Debug.Log("ticketenter");
            sticky = true;
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == ItemNameContains || other.name == hand1 || other.name == hand2)
        {
            Debug.Log("ticketExit");
            sticky = false;

            StartCoroutine(Stupid());
        }


    }


    IEnumerator Stupid()
    {


       
        yield return new WaitForSeconds(1f);
        sticky = false;


    }
}
