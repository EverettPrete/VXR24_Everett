using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objectsToDuplicate;  // Assign objects to be duplicated in the Inspector
    public GameObject clearObject;            // Assign the clear object in the Inspector

    private List<GameObject> duplicates = new List<GameObject>();  // List to track duplicates
    private int duplicateCount = 0;           // Track how many duplicates have been created
    private const int maxDuplicates = 3;      // Maximum number of duplicates allowed
    private Vector3 lastSpawnPosition;        // Track the last spawn position

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
            ClearDuplicates();
    }

    private bool IsMouseOverObject(GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == obj;
    }

    private void DuplicateObject(GameObject obj)
    {
        if (duplicateCount < maxDuplicates)
        {
            GameObject duplicate = Instantiate(obj, lastSpawnPosition, Quaternion.identity);
            duplicates.Add(duplicate);  // Track the duplicate
            lastSpawnPosition += Vector3.right;  // Move position for the next duplicate
            duplicateCount++;
        }
    }

    private void ClearDuplicates()
    {
        foreach (GameObject duplicate in duplicates)
            Destroy(duplicate);
        duplicates.Clear();  // Reset duplicates
        duplicateCount = 0;  // Reset count
        lastSpawnPosition = Vector3.zero;  // Reset position
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