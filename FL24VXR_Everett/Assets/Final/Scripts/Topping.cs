using System.Collections;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Topping : MonoBehaviour
{
    public GameObject ToppingsPrefab; // The prefab to duplicate
    public GameObject FlatToppings;
    

    public BoxCollider SpecificBoxCollider; // The specific BoxCollider to check against
    public GameObject TargetObject; // The object to use as the target for duplication
    public bool OutOfBox = false; // Flag to control whether a new duplicate can be spawned
    public bool Starting = true;

    public bool WasDuplicatedByTimer = false;
    public bool WasDuplicatedByCollider = false;  

    public float offset = 0.0005f;
    public void Start()
    {
        OutOfBox = false;
        WasDuplicatedByCollider = false;
        WasDuplicatedByTimer = false;
        if (Starting)
        {
            Starting = false;

            DuplicateTopping();
        }   
    }
    private void OnTriggerExit(Collider other)
    {     
        if (other == SpecificBoxCollider && OutOfBox == false)
        {
            Debug.Log("topping has exited the building");
            DuplicateTopping();

      //  StartCoroutine(AntiDuplicationFunction());
            OutOfBox = true;
        }
    }
    IEnumerator AntiDuplicationFunction()
    {
        yield return new WaitForSeconds(3f);
       if (WasDuplicatedByCollider == false) 
        {
           // Debug.Log("wasduplicatedby timer");
          //  DuplicateTopping();
         //   WasDuplicatedByTimer = true;
        }
    }
    public void DuplicateTopping()
    {
        Vector3 targetPosition = TargetObject.transform.position;
        GameObject duplicate = Instantiate(ToppingsPrefab, targetPosition, Quaternion.identity);

        Rigidbody rb = duplicate.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }


    //this puts the flat topping on the pizza and destroys the ball topping
     /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cooked") && OutOfBox)
        {
 
            GameObject duplicate = Instantiate(FlatToppings, other.transform.position, other.transform.rotation);
       duplicate.transform.SetParent(other.transform);
            duplicate.transform.localPosition = new Vector3(0, 0, offset);
           


            if (WasDuplicatedByTimer == false)
            {
             
                DuplicateTopping();
                WasDuplicatedByCollider = true;
                Debug.Log("was duplicated by collider");
            }

           //  gameObject.SetActive(false);

        }
    }
        */

   
}
