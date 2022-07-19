using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBuffSlot : MonoBehaviour
{
    public Image durationOverlay;
    [SerializeField]
    private Image backdrop;

    [HideInInspector]
    public float maxDuration;
    [HideInInspector]
    public float currDuration;

    void Start()
    {
        currDuration = maxDuration;
        backdrop = durationOverlay;
    }

    void Update()
    {
        if(currDuration > 0)
        {
            currDuration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        durationOverlay.fillAmount = currDuration / maxDuration;
    }
}