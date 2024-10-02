using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class transform : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();

        RotateCube();

        ScaleCube();

        if (Input.GetKeyDown(KeyCode.L))
        {
            LookAtTarget();
        }



    }


    private void MoveCube()
    {
        float moveSpeed = 5f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }


    void RotateCube()
    {
        float rotationSpeed = 50f;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void ScaleCube()
    {
        Vector3 scalechange = new Vector3(1,1,1) * Time.deltaTime;  
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= scalechange;
        }
       
        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += scalechange;
        }

    }
    void LookAtTarget()
    {
        if(target != null)
        {
            transform.LookAt(target);
        }
        else
        {
            Debug.LogWarning("NO TARGET ASSIGNED");
        }
    }



}
