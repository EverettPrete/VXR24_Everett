using UnityEngine;

public class PlaceDownSauce : MonoBehaviour
{
    public PickupSauce PickupSauce;
   
    void OnTriggerStay(Collider other)
    {
      

        // Check if the object that collided has the "Dough" tag
        if (other.CompareTag("Dough") && PickupSauce.SpoonHasSauce)
        {
            // Try to get the MeshRenderer component from the collided object
            MeshRenderer collidedMeshRenderer = other.GetComponent<MeshRenderer>();

           
                collidedMeshRenderer.enabled = true; // Enable the MeshRenderer
                PickupSauce.SpoonHasSauce = false; // Reset the flag
            PickupSauce.targetMeshRenderer.enabled = false;
            
            
        }
    }
}
