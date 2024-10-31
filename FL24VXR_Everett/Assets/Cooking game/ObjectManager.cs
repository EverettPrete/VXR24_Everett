using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objectsToDuplicate;  
    public GameObject clearObject;           

    private List<GameObject> duplicates = new List<GameObject>();  // List to track duplicates
    private int duplicateCount = 0;        
    private const int maxDuplicates = 3;     
    public Vector3 spawnPosition = new Vector3(-1.27f,2,-2.57f);
    
   

    void Update()
    {
        // Check for clicks on objects to duplicate
        foreach (GameObject obj in objectsToDuplicate)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOverObject(obj))
            {
                DuplicateObject(obj);
                OutputObjectID(obj);  // Output ID when clicked
              
            }
        }

        // Check for clicks on the clear object
        if (Input.GetMouseButtonDown(0) && IsMouseOverObject(clearObject))
        {
               ClearDuplicates();
              
        }
        
      
          
    }

    private bool IsMouseOverObject(GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == obj;
    }

    public void DuplicateObject(GameObject obj)
    {
        if (duplicateCount < maxDuplicates)
        {
            GameObject duplicate = Instantiate(obj, spawnPosition, Quaternion.identity);
            duplicates.Add(duplicate);  // Track the duplicate
            spawnPosition += Vector3.right*1.5f;  // Move position for the next duplicate
            duplicateCount++;
            duplicate.tag = "Clones";

        }
    }

    private void ClearDuplicates()
    {
        foreach (GameObject duplicate in duplicates)
            Destroy(duplicate);
        duplicates.Clear();  // Reset duplicates
        duplicateCount = 0;  // Reset count
       spawnPosition = new Vector3(-1.27f, 2, -2.57f);  // Reset position
    }

    private void OutputObjectID(GameObject obj)
    {
        ObjectID objectID = obj.GetComponent<ObjectID>();
        if (objectID != null)
        {
            Debug.Log("Object ID: " + objectID.id);
        }
    }

   


}