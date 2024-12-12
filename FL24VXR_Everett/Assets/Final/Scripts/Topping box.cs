using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toppingbox : MonoBehaviour
{
    public bool toppingInBox = false;
    public GameObject ToppingReplacement;
    public GameObject SpawnLocation;
    public string BallObjectName = "";

    public GameObject Hand1;
    public GameObject Hand2;
    private void Start()
    {
   //     StartCoroutine(ToppingTimerReplacement());
    }
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject == Hand1 )
        {
            spawnNewTopping();
            Debug.Log("collided with hand");
        }
       

    }
    


   
/*
    IEnumerator ToppingTimerReplacement()
    {
        if (toppingInBox == false)
        {
            while (true)
            {
               
                Debug.Log("Action triggered!");
                spawnNewTopping();
                yield return new WaitForSeconds(5f); // Wait for 5 seconds
            }
        }
    }
*/
    private void spawnNewTopping()
    {
        Vector3 targetPosition = SpawnLocation.transform.position;
        ToppingReplacement = Instantiate(ToppingReplacement, targetPosition, Quaternion.identity);
        Debug.Log("toppingwasduplicated");
    }

}
