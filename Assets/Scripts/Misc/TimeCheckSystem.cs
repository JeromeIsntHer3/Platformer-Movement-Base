using UnityEngine;
using TMPro;
using System;

public class TimeCheckSystem : MonoBehaviour
{
    [SerializeField]
    private float timeCycle;
    [SerializeField]
    private float internalTimeCycle;

    [SerializeField]
    private TextMeshProUGUI timeDisplay;
    [SerializeField]
    private TextMeshProUGUI internalTimeDisplay;

    private float timeCountdown;
    public float TimeCountDown { get { return timeCountdown; } }
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
            timeCountdown = timeCycle;
        }
        TimeSpan timePlaying = TimeSpan.FromSeconds(timeCountdown);
        string timeString = timePlaying.ToString("mm':'ss");
        timeDisplay.text = timeString;
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
        TimeSpan internalTimePlaying = TimeSpan.FromSeconds(internalTimeCountdown);
        string internalTimeString = internalTimePlaying.ToString("mm':'ss");
        internalTimeDisplay.text = internalTimeString;
    }

    public void Update()
    {
        TimeCycle();
    }
}