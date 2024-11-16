using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialController : MonoBehaviour
{
    public CookFood CookFood;  // Reference to CookFood script

    public TMP_Text buttontext;

    public Transform dialTransform; // The transform of the dial
    public float minValue = 0f;     // Minimum value of the variable
    public float maxValue = 10f;    // Maximum value of the variable
    public float sensitivity = 1f;  // Sensitivity of the rotation to value change

    private float previousAngle = 0f;  // Tracks the previous angle for rotation calculation
    private float rotationOffset = 0f; // Used to store the initial rotation angle when grabbing

    private void Start()
    {
        if (dialTransform == null)
        {
            dialTransform = transform;
        }
        CookFood.heat = minValue;  // Initialize heat value
        previousAngle = GetDialAngle();  // Get the initial angle
    }

    private void Update()
    {
        // Only update when the dial is being interacted with (i.e., grabbed by the user)
        if (IsDialGrabbed())
        {
            float currentAngle = GetDialAngle();  // Get the current angle of the dial
            float angleDelta = Mathf.DeltaAngle(previousAngle, currentAngle);  // Calculate the change in angle
            previousAngle = currentAngle;  // Update the previous angle

            // Update the heat variable based on the dial's rotation
            CookFood.heat = Mathf.Clamp(CookFood.heat + angleDelta * sensitivity / 360f * (maxValue - minValue), minValue, maxValue);

            Debug.Log("Dial Value (heat): " + CookFood.heat);

            buttontext.text = "Heat: " + CookFood.heat.ToString();
        }
    }

    // Check if the dial is currently grabbed by the VR controller
    private bool IsDialGrabbed()
    {
        // Implement your logic to check if the dial is currently grabbed
        // Example: If using XR Toolkit, check if it's selected.
        // Return true if the dial is being interacted with.
        return true;  // Replace with actual interaction check
    }

    // Calculate the angle of rotation around the Y-axis
    private float GetDialAngle()
    {
        // Get the rotation of the dial object around its Y-axis
        Vector3 localForward = transform.InverseTransformDirection(transform.forward);
        float angle = Mathf.Atan2(localForward.x, localForward.z) * Mathf.Rad2Deg;

        return angle;
    }

    // Optionally, you can add functionality for when grabbing starts or ends to reset rotation offset
    private void OnGrabStarted()
    {
        rotationOffset = GetDialAngle();  // Store the initial rotation offset when grabbed
    }

    private void OnGrabEnded()
    {
        rotationOffset = 0f;  // Reset offset when the grab ends
    }
}
