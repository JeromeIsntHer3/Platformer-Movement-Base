using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedPlatform : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]private float standOnPercentage;
    [SerializeField]
    private float increaseRate;
    [SerializeField]
    private float decreaseRate;
    [SerializeField]
    private SpriteRenderer sprite;
    private bool onPlatform;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            onPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            onPlatform = false;
        }
    }

    private void Update()
    {
        if(standOnPercentage > 0 && !onPlatform)
        {
            standOnPercentage -= decreaseRate * Time.fixedDeltaTime;
        }
        if(standOnPercentage < 100 && onPlatform)
        {
            standOnPercentage += increaseRate * Time.fixedDeltaTime;
        }
        sprite.color = new Color(1,1,standOnPercentage/100);
    }
}