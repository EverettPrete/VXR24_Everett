using JetBrains.Annotations;
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