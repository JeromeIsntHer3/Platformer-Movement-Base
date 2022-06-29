using UnityEngine;
using TMPro;
using System;

public abstract class TimeCheckSystem : MonoBehaviour
{
    [Header("Cycles")]
    public float timeCycle;
    public float internalTimeCycle;

    [Header("Displays")]
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI internalTimeDisplay;

    private float timeCountdown;
    private float internalTimeCountdown;

    public Player player;

    void Start()
    {
        if (timeCycle >= timeCountdown)
        {
            timeCountdown = timeCycle;
        }
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
        if (internalTimeCountdown <= 0)
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

    // Update is called once per frame
    void Update()
    {
        TimeCycle();
        InternalTimeCycle();
        DisplayTime();
    }

    //3 Segment 15
    //
}
