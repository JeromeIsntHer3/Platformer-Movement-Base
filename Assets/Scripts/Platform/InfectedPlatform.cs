using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedPlatform : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]private float standOnPercentage;
    private float maxPercentage = 100;
    [SerializeField]
    private float increaseRate;
    [SerializeField]
    private float decreaseRate;
    [SerializeField]
    private Color finalColor;
    private SpriteRenderer sr;
    private bool onPlatform;

    [SerializeField]
    private string tagCompare;

    private void Awake()
    {
        sr = GetComponentInParent<SpriteRenderer>();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == tagCompare)
        {
            onPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == tagCompare)
        {
            onPlatform = false;
        }
    }

    private void FixedUpdate()
    {
        if(standOnPercentage > 0 && !onPlatform)
        {
            standOnPercentage -= decreaseRate * Time.fixedDeltaTime;
        }
        if(standOnPercentage < 100 && onPlatform)
        {
            standOnPercentage += increaseRate * Time.fixedDeltaTime;
        }
        Color color = Color.Lerp(Color.white, finalColor, standOnPercentage / maxPercentage);
        sr.color = color;
    }
}