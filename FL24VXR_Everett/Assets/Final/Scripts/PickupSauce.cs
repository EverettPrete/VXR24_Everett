using UnityEngine;

public class PickupSauce : MonoBehaviour
{
    // Reference to the MeshRenderer on the third object (the one to be triggered)
    public MeshRenderer targetMeshRenderer;

    // Tag of objects that will trigger the MeshRenderer
    public string triggeringTag1 = "Spoon";
    public string triggeringTag2 = "Container";

    public bool SpoonHasSauce = false; // Example flag to track sauce status


   
    void OnTriggerStay(Collider other)
    {
     

        // Check if the object that collided has the specified tags
        if (other.CompareTag(triggeringTag1) || other.CompareTag(triggeringTag2))
        {
          
                targetMeshRenderer.enabled = true;
                SpoonHasSauce = true;
               
               
            
        }
    }
}
