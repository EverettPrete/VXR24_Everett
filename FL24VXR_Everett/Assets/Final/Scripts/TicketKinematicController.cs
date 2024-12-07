using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketKinematicController : MonoBehaviour
{
    public string ItemNameContains = "";
    
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains(ItemNameContains))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;

        }

    }
}
