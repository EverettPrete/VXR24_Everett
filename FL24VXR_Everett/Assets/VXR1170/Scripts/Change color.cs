using UnityEngine;
using UnityEngine.UI;

public class Change_color : MonoBehaviour
{
    public GameObject targetObject; // Object to change color
    public Button button;           // Button to trigger color change
    public Color newColor = Color.red; // Color to change to

    private void Start()
    {
        // Add a listener to the button to call the ChangeColor function when clicked
        if (button != null)
        {
            button.onClick.AddListener(ChangeColor);
        }
    }

    private void ChangeColor()
    {
        // Change the color of the target object's material
        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = newColor;
            }
        }
    }
}