using System.Collections;
using UnityEngine;

public class Topping : MonoBehaviour
{
    public GameObject ToppingsPrefab; // The prefab to duplicate
    public GameObject FlatToppings;
    private const string DuplicateTag = "Duplicate";
    public BoxCollider SpecificBoxCollider; // The specific BoxCollider to check against
    public GameObject TargetObject; // The object to use as the target for duplication
    public bool canSpawn = true; // Flag to control whether a new duplicate can be spawned

    private void OnTriggerExit(Collider other)
    {
      
        // Check if the exiting collider is the specific BoxCollider and if we can spawn
        if (other == SpecificBoxCollider && canSpawn)
        {
        
            StartCoroutine(DuplicateTopping());

            canSpawn = true;
        }
    }

    IEnumerator DuplicateTopping()
    {
       
        yield return new WaitForSeconds(0.5f);
        if (TargetObject != null)
        { 
            Collider[] colliders = Physics.OverlapBox(SpecificBoxCollider.transform.position, SpecificBoxCollider.size / 2, Quaternion.identity);
            foreach (Collider col in colliders)
            {            
                if (col.CompareTag(DuplicateTag))
                {
                    
                    canSpawn = false;
                    yield break;
                }
            }        
            Vector3 targetPosition = TargetObject.transform.position;   
            GameObject duplicate = Instantiate(ToppingsPrefab, targetPosition, Quaternion.identity);
            duplicate.transform.localScale = transform.localScale;
            Rigidbody rb = duplicate.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;  
                rb.useGravity = true;    
            }
            duplicate.tag = DuplicateTag;
        }
        else
        {
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Dough") && !canSpawn)
        {       
            GameObject duplicate = Instantiate(FlatToppings);
         
            duplicate.transform.position = other.transform.position;

            duplicate.transform.SetParent(other.transform);
 
            
                Destroy(ToppingsPrefab);
           
        }
    }

}
