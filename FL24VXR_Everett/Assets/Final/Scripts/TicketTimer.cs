using UnityEngine;

public class TicketTimer : MonoBehaviour
{
    public float heightOffset = -1f;  // Offset from the parent object
    public float widthOffset = -0.155f;

    public GameObject GameOverCanvas;

    public PizzaCheck PizzaCheck;
    public TicketScript TicketScript;

    private Animator animator;

    public Renderer objectRenderer;  // Assign the object's renderer in the Inspector
    public Color startingEmissionColor = Color.black;  // Initial emission color (black = no emission)
    public Color targetEmissionColor = Color.red;  // The emission color to fade into
    public float fadeDuration = 30f;  // Duration of the fade in seconds

    public bool StartingBone = true;

    public Renderer TicketColor;

    private Color initialEmissionColor;  // Store the initial emission color for fading
    public float fadeTimer = 0f;  // Timer to track the fade progress

    void Start()
    {
        StartingBone = PizzaCheck.StartingBone;
        // Get the Renderer component
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        // Enable emission keyword for the material
        objectRenderer.material.EnableKeyword("_EMISSION");

        // Set the initial emission color
        objectRenderer.material.SetColor("_EmissionColor", startingEmissionColor);

        // Store the initial emission color for the fade
        initialEmissionColor = startingEmissionColor;

        // Reset fade timer
        fadeTimer = 0f;


        animator = GetComponent<Animator>();
    }
   
  

    void Update()
    {
        if (StartingBone == false && TicketScript.IsActive == true)
            fadeTimer += Time.deltaTime;
        float t = fadeTimer / fadeDuration;  // Normalize time (0 to 1)

        // Lerp the emission color from initial to target and set it on the material
        Color newEmissionColor = Color.Lerp(initialEmissionColor, targetEmissionColor, t);
        objectRenderer.material.SetColor("_EmissionColor", newEmissionColor);

        if (fadeTimer > fadeDuration - 5)
        {
            animator.Play("TicketTimerAnimation");

        }

        //GAME OVER
        if (fadeTimer > fadeDuration && TicketScript.IsActive == true)
        {
            TicketColor.material.color = Color.black;
            Debug.Log("GAMEOVER");
            GameOverCanvas.SetActive(true);
        }
        


    }

  
}
