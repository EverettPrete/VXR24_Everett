using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketKinematicController : MonoBehaviour
{
    public string ItemNameContains = "";
    public Rigidbody RigidTicket;
    public string hand1 = "";
    public string hand2 = "";
    private void Start()
    {
        if (RigidTicket == null)
        {
            RigidTicket = GetComponent<Rigidbody>();
            if (RigidTicket == null)
            {
                Debug.LogError("RigidTicket not found or assigned!");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == ItemNameContains)
        {
            Debug.Log("ticketenter");
            RigidTicket.isKinematic = true;
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == ItemNameContains || other.name == hand1 || other.name == hand2)
        {
            Debug.Log("ticketExit");
            RigidTicket.isKinematic = false;
            
            StartCoroutine(Stupid());
        }


    }

    IEnumerator Stupid()
    {


       
        yield return new WaitForSeconds(1f);
        RigidTicket.isKinematic = false;



    }
}
