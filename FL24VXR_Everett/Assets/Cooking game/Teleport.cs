using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI scoreText;
   

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;



    public ObjectManager objectManager;
   


    public float streak = 0;
    public float score = 0;


    private void Start()
    {
        createAndDestroyClones(); //run at start so that the game starts with a recipe
    }
    private void OnMouseDown()
    {
        compare();       //compares the two arrays to see if they match
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
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clones");  //finds all objects tagged with "clone"

        int recipe1Count = 0, recipe2Count = 0, recipe3Count = 0;  //gives all of the clones a value of 0
        int ing1Count = 0, ing2Count = 0, ing3Count = 0;
        bool match1 = false, match2 = false, match3 = false;   //assumes that all the matches are false untill proven a match
        Debug.Log("length: "+clones.Length);

        foreach (GameObject clone in clones)   // runs it a number of times equal to how many clones there are
        {
       
            string name = clone.name;
            Debug.Log("Clone name: " + name);

            if (name.StartsWith("Recipe"))  // if an object starts with "recipe" then look at it and give it a value
            {
                if (name.EndsWith("1(Clone)")) recipe1Count++;
                else if (name.EndsWith("2(Clone)")) recipe2Count++;
                else if (name.EndsWith("3(Clone)")) recipe3Count++;
            }
            else if (name.StartsWith("Ingredient"))  // if an object starts with "ingredient" then look at it and give it a value
            {
                if (name.EndsWith("1(Clone)")) ing1Count++;
                else if (name.EndsWith("2(Clone)")) ing2Count++;
                else if (name.EndsWith("3(Clone)")) ing3Count++;
            }
        }

     

        if(recipe1Count == ing1Count) match1 = true; // check if they match then set the bool to true
        if(recipe2Count == ing2Count) match2 = true;
        if(recipe3Count == ing3Count) match3 = true;

        if (match1 && match2 && match3) // if they all match then add score to the thing  and increase it, as well as the score muliplyer
        {
            Debug.Log("All recipes and ingredients have matching counts!");
            scoreText.text = "Score:" + score.ToString();

            streak += 1;
            score += 1*streak;

        }
        else // if its wrong, dont add any score and reset the streak
        {
            Debug.Log("The counts do not match.");
            streak = 0;
        }
    }

    
    void InstantiateRandomObject(int index)   // instantiate a random selection of objects
    {
        // Array of objects to randomly pick from
        GameObject[] objects = { object1, object2, object3 }; //set up the array and then add the objects to it in the inspector

        // Get a random index
        int randomIndex = Random.Range(0, objects.Length); // pick a random one 

        // Instantiate the selected object at a new position
        Vector3 spawnPosition = new Vector3(index * 1.5f -8, -3.25f, 0);  //put it in the first position and if theres already one there put it inside
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