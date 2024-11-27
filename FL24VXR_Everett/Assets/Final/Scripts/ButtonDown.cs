
using TMPro;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
   public CookFood CookFood;
    
    private float score = 0;
    public TMP_Text buttontext;

    public bool burnerOn = false;

    // Add references for color toggling
    public Renderer targetRenderer; // Renderer of the GameObject to toggle color
    public Color colorA = Color.white; // First color
    public Color colorB = Color.green; // Second color
    public Light targetLight;
    private bool isColorAToggle = true; // Tracks the current color state

    private bool hasInteracted = false; // Flag to prevent multiple interactions
    public float resetDelay = 0.5f; // Optional delay to reset interaction

    // Method to set the score and toggle color
    public void Score()
    {
        if (hasInteracted) return; // Exit if interaction already occurred

        hasInteracted = true; // Mark as interacted
        score++;
        buttontext.text = "Score: " + score.ToString();

        ToggleColor();
        ToggleBurner();

        // Reset the interaction after a delay if needed
        Invoke(nameof(ResetInteraction), resetDelay);
    }

    // Method to toggle the GameObject's color
    private void ToggleColor()
    {
        targetRenderer.material.color = isColorAToggle ? colorB : colorA;
        isColorAToggle = !isColorAToggle;
    }

    private void ToggleBurner()
    {
        burnerOn = !burnerOn; // Toggle the burner state
      targetLight.enabled = burnerOn;
    }

    // Reset interaction flag
    private void ResetInteraction()
    {
        hasInteracted = false;
    }
}
