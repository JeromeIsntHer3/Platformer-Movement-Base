using UnityEngine;
using System;

public class Player : MonoBehaviour,HealthInterfaces
{
    public float currHealth;
    public HealthBar healthBar;
    public float dot, hot;


    private event EventHandler OnHealthChanged;

    void Awake()
    {
        currHealth = 100;
    }

    void Start()
    {
        OnHealthChanged += HealthChanged;
    }

    void Update()
    {
    }

    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Health Change
    public void HealthChanged(object sender,EventArgs e)
    {

    }

    public void Heal()
    {
        currHealth += 5f;
        if (currHealth >= 100) currHealth = 100;
        SetAndInvoke();
    }

    public void Damage()
    {
        currHealth -= 10f;
        if (currHealth <= 0) currHealth = 0;
        SetAndInvoke();
    }

    public void DOT()
    {
        currHealth -= dot * Time.deltaTime;
        SetAndInvoke();
    }

    public void HOT()
    {
        currHealth += hot * Time.deltaTime;
        SetAndInvoke();
    }

    public void SetAndInvoke()
    {
        healthBar.SetHealth();
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
