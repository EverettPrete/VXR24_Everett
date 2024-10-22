using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerValue = 30f;
    [SerializeField] TextMeshProUGUI timerText;

    private void Start()
    {
        StartCoroutine(BeginTimer());
    }

    IEnumerator BeginTimer()
    {
        while (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timerValue);
            yield return null;
        }
        timerText.text = "Time: 0";
    }
}