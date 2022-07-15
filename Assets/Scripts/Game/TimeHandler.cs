using UnityEngine;
using TMPro;
using System;

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    private float timeCycle;
    //[SerializeField]
    //private float internalTimeCycle;

    [SerializeField]
    private float tick;

    [SerializeField]
    private TextMeshProUGUI timeDisplay;
    //[SerializeField]
    //private TextMeshProUGUI internalTimeDisplay;

    private float timeCountdown;
    public float TimeCountDown { get { return timeCountdown; } }
    //private float internalTimeCountdown;

    public void OnEnable()
    {
        timeCountdown = timeCycle;
        GameObject display = GameObject.Find("Time");
        timeDisplay = display.transform.GetComponent<TextMeshProUGUI>();
    }

    void TimeCycle()
    {
        if (timeCountdown > 0)
        {
            timeCountdown -= tick * Time.deltaTime;
        }
        if (timeCountdown <= 0)
        {
            timeCountdown = timeCycle;
        }
        TimeSpan timePlaying = TimeSpan.FromSeconds(timeCountdown);
        string timeString = timePlaying.ToString("mm':'ss");
        timeDisplay.text = timeString;
    }

    //void InternalTimeCycle()
    //{
    //    if (internalTimeCountdown > 0)
    //    {
    //        internalTimeCountdown -= tick * Time.deltaTime;
    //    }
    //    if (internalTimeCountdown <= 0 && timeCountdown != 0)
    //    {
    //        internalTimeCountdown = internalTimeCycle;
    //    }
    //    TimeSpan internalTimePlaying = TimeSpan.FromSeconds(internalTimeCountdown);
    //    string internalTimeString = internalTimePlaying.ToString("mm':'ss");
    //    internalTimeDisplay.text = internalTimeString;
    //}

    public void StopTime()
    {
        timeCountdown = 0;
        tick = 0;
    }

    public void Update()
    {
        TimeCycle();
    }
}