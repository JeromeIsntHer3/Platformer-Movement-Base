using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour, HealthInterfaces, ProgressInterfaces
{
    public float currHealth;
    public float currProgress;

    public float dot;
    public float hot;

    private float prevHealth;
    private float prevProgress;
    
    //Events for Changes In Health & Progress
    //This Events run and are used in HealthChanged
    //and ProgressChanged
    public event EventHandler OnHealthChange, OnProgressChange;

    void Awake()
    {
    }

    void Start()
    {
    }

    #region HealthChanged
    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Health Change
    public void HealthChanged()
    {
        if (currHealth > prevHealth || currHealth < prevHealth)
        {
            OnHealthChange?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion

    #region ProgressChanged
    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Progress Change
    public void ProgressChanged()
    {
        if (currProgress > prevProgress || currProgress < prevProgress)
        {
            OnProgressChange?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion

    #region Interface Functions
    public void Heal(float healAmount)
    {
        prevHealth = currHealth;
        currHealth += healAmount;
        if (currHealth >= 100) currHealth = 100;
    }

    public void Damage(float damageAmount)
    {
        prevHealth = currHealth;
        currHealth -= damageAmount;
        if (currHealth <= 0) currHealth = 0;
    }

    public void DOT()
    {
        prevHealth = currHealth;
        currHealth -= dot * Time.deltaTime;
    }

    public void HOT()
    {
        prevHealth = currHealth;
        currHealth += hot * Time.deltaTime;
    }

    public void ProgressIncrease(float increaseProgress, float cap)
    {
        prevProgress = currProgress;
        currProgress += increaseProgress;
        if (currProgress >= cap) currProgress = cap;
    }

    public void ProgressDecrease(float decreaseProgress)
    {
        prevProgress = currProgress;
        currProgress -= decreaseProgress;
        if (currProgress <= 0) currProgress = 0;
    }
    #endregion

    void Update()
    {
        HealthChanged();
        ProgressChanged();
    }
}