using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public ObjectManager objectManager;

    private void Start()
    {
        createAndDestroyClones();
    }
    private void OnMouseDown()
    {
        compare();
        createAndDestroyClones();
        
    }






    public void createAndDestroyClones()
    {

        // Destroy all current clones
        DestroyClones();

        // After destroying, instantiate new random objects
        for (int i = 0; i < 3; i++)

            InstantiateRandomObject(i);
    }

    void compare()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clones");

        int recipe1Count = 0, recipe2Count = 0, recipe3Count = 0;
        int ing1Count = 0, ing2Count = 0, ing3Count = 0;
        bool match1 = false, match2 = false, match3 = false;
        Debug.Log("length: "+clones.Length);

        foreach (GameObject clone in clones)
        {
       
            string name = clone.name;
            Debug.Log("Clone name: " + name);

            if (name.StartsWith("Recipe"))
            {
                if (name.EndsWith("1(Clone)")) recipe1Count++;
                else if (name.EndsWith("2(Clone)")) recipe2Count++;
                else if (name.EndsWith("3(Clone)")) recipe3Count++;
            }
            else if (name.StartsWith("Ingredient"))
            {
                if (name.EndsWith("1(Clone)")) ing1Count++;
                else if (name.EndsWith("2(Clone)")) ing2Count++;
                else if (name.EndsWith("3(Clone)")) ing3Count++;
            }
        }

     

        if(recipe1Count == ing1Count) match1 = true;
        if(recipe2Count == ing2Count) match2 = true;
        if(recipe3Count == ing3Count) match3 = true;

        if (match1 && match2 && match3)
        {
            Debug.Log("All recipes and ingredients have matching counts!");
        }
        else
        {
            Debug.Log("The counts do not match.");
        }
    }

    
    void InstantiateRandomObject(int index)
    {
        // Array of objects to randomly pick from
        GameObject[] objects = { object1, object2, object3 };

        // Get a random index
        int randomIndex = Random.Range(0, objects.Length);

        // Instantiate the selected object at a new position
        Vector3 spawnPosition = new Vector3(index * 1.5f -8, -3.25f, 0);
        GameObject newObject = Instantiate(objects[randomIndex], spawnPosition, Quaternion.identity);

        // Tag the new object as "Clones"
        newObject.tag = "Clones";
    }

    void DestroyClones()
    {
        // Find all GameObjects with the tag "Clones"
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clones");

        // Destroy each clone
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
    }
}