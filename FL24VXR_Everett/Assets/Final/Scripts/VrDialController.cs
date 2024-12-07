using UnityEngine;

public class VRDialController : MonoBehaviour
{
    [Header("Dial Settings")]
    public float minRotation = 0f;
    public float maxRotation = 270f;
    public float valueRange = 100f;

    [Header("Output Value")]
    public float outputValue;

    [Header("Dial Synchronization")]
    public Transform mimicDial;
    private bool isBeingGrabbed = false;

    private float initialVisualYRotation;
    private float initialInteractorYRotation;
    private float changeInRotation;

    public GameObject DialVisual;         // The visual dial object
    public GameObject DialInteractor;     // The interactor (grabber) object

    void Update()
    {
        if (isBeingGrabbed)
        {
            // Get the current Y rotation of the interactor (controller)
            float currentInteractorYRotation = DialInteractor.transform.eulerAngles.y;

            // Calculate the change in rotation from the initial grab point
            float deltaRotation = currentInteractorYRotation - initialInteractorYRotation;

            // Apply the change in rotation to the visual dial's Y rotation (local rotation)
            float newYRotation = initialVisualYRotation + deltaRotation;

            // Clamp the rotation to stay within the defined range
            newYRotation = Mathf.Clamp(newYRotation, minRotation, maxRotation);

            // Update the visual dial's local rotation based on the Y-axis
            DialVisual.transform.localRotation = Quaternion.Euler(0f, newYRotation, 0f);
        }
    }

    public void OnGrabbed()
    {
        isBeingGrabbed = true;

        // Store the initial rotation of the interactor and the visual dial at the start of the grab
        initialInteractorYRotation = DialInteractor.transform.eulerAngles.y;
        initialVisualYRotation = DialVisual.transform.eulerAngles.y;
    }

    public void OnReleased()
    {
        isBeingGrabbed = false;

        // Optionally, store the final rotation or perform other actions on release
        initialVisualYRotation = DialVisual.transform.eulerAngles.y;
    }
}
