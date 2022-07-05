using UnityEngine;
using TMPro;
using System;

public class TimeCheckSystem : MonoBehaviour
{
    private float timeCycle;
    private float internalTimeCycle;
    
    private TextMeshProUGUI timeDisplay;
    private TextMeshProUGUI internalTimeDisplay;

    private float timeCountdown;
    private float internalTimeCountdown;

    public void Start()
    {
        timeCountdown = timeCycle;
    }

    void TimeCycle()
    {
        if (timeCountdown > 0)
        {
            timeCountdown -= 1 * Time.deltaTime;
        }
        if (timeCountdown <= 0)
        {
            timeCountdown = 0;
        }
    } 

    void InternalTimeCycle()
    {
        if (internalTimeCountdown > 0)
        {
            internalTimeCountdown -= 1 * Time.deltaTime;
        }
        if (internalTimeCountdown <= 0 && timeCountdown != 0)
        {
            internalTimeCountdown = internalTimeCycle;
        }
    }

    void DisplayTime()
    {
        var timePlaying = TimeSpan.FromSeconds(timeCountdown);
        string timeString = timePlaying.ToString("mm':'ss");
        var internalTimePlaying = TimeSpan.FromSeconds(internalTimeCountdown);
        string internalTimeString = internalTimePlaying.ToString("mm':'ss");
        timeDisplay.text = timeString;
        internalTimeDisplay.text = internalTimeString;
    }

    public void Update()
    {
        TimeCycle();
        InternalTimeCycle();
        DisplayTime();
    }
}