using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTrack : MonoBehaviour
{
    bool timerActive = false;
    public TextMeshProUGUI elapsedText;
    float timeElapsed;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timerActive)
        {
            timeElapsed += Time.deltaTime;
        }
        elapsedText.text = Mathf.Round(timeElapsed).ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
