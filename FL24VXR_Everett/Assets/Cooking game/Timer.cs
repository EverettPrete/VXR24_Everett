using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerValue = 30f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI gameover;

    public GameObject endscreen;
    public Vector3 X;

    public void Start()
    {
        StartCoroutine(BeginTimer());
    }

    IEnumerator BeginTimer()
    {
        while (timerValue >= 0)  
        {
            timerValue -= Time.deltaTime;       //reduces the time
            timerText.text = "Time: " + Mathf.CeilToInt(timerValue);
            yield return null;

            gameover.enabled = false;           //hides the "game over" text
        }
        
        timerText.text = "Time: 0";
     
       
        if (timerValue <0)
        {
            gameover.enabled = true;         //shows the "game over" text
            endscreen.transform.position = X;   //hides all the objects
            
        }
           
        
    }

}