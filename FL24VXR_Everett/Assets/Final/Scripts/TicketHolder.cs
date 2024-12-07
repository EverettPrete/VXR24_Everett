using UnityEngine;

public class TicketHolder : MonoBehaviour
{

    public string TagName = "";



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == (TagName))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

        }

    }
}
