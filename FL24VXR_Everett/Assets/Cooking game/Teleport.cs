using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Rendering;
using UnityEditor.VersionControl;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public bool panFull = false;
   
    private void OnMouseDown()
    {
     
          
            // Find all objects with the tag "Clones"
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clones");

            // Loop through each object and destroy it
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        
        


        for (int i = 0; i < 3; i++)
        {
            InstantiateRandomObject(i);  
        }
       


        
    }

    void InstantiateRandomObject(int x)
    {
        // Create an array with the GameObjects
        GameObject[] objects = { object1, object2, object3 };

        // Get a random index
        int randomIndex = Random.Range(0, objects.Length);

        // Instantiate the randomly selected GameObject at a desired position and rotation
        GameObject newObject = Instantiate(objects[randomIndex], new Vector3(x * 1.5f - 2, 0, 0), Quaternion.identity); // Change Vector3.zero to your desired position

        // Tag the new object as "Clones"
        newObject.tag = "Clones";
    }

}