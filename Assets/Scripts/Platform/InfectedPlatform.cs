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
    private float damage;
    [SerializeField]
    private Color finalColor;
    private SpriteRenderer sr;
    private bool onPlatform;
    private BacteriaHandler enemyHandler;

    [SerializeField]
    private string tagCompare;

    private void Awake()
    {
        sr = GetComponentInParent<SpriteRenderer>();
        enemyHandler = FindObjectOfType<BacteriaHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == tagCompare)
        {
            onPlatform = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(standOnPercentage >= 100f && other.tag == tagCompare)
        {
            if (enemyHandler == null) return;
            if (enemyHandler.BacteriaCount() > 25) return;
            enemyHandler.SpawnBacteria(enemyHandler.BacteriaCount());
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