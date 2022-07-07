using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Player : MonoBehaviour, HealthInterfaces, ProgressInterfaces
{
    [Header("Set Health and Progress")]
    [SerializeField]
    private float _currHealth;
    [SerializeField]
    private float _currProgress;

    private float dotDam;
    private float hotHeal;
    private bool doDOT;
    private bool doHOT;

    private float prevHealth;
    private float prevProgress;

    [SerializeField]
    private GameObject barrier;
    private float barrierDuration;

    [HideInInspector]
    public TimeHandler timeHandler;

    //PROPERTIES
    public float CurrHealth { get { return _currHealth; } }
    public float CurrProgress { get { return _currProgress; } }
    public float DOTDam { get { return dotDam; } set { dotDam = value; } }
    public float HOTDam { get { return hotHeal; } set { hotHeal = value; } }
    public bool DoDOT { get { return doDOT; } set { doDOT = value; } }
    public bool DoHOT { get { return doHOT; } set { doHOT = value; } }

    
    //Events for Changes In Health & Progress
    //This Events run and are used in HealthChanged
    //and ProgressChanged
    public event EventHandler OnHealthChange, OnProgressChange;

    #region HealthChangedEventTrigger

    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Health Change
    public void HealthChanged()
    {
        if (_currHealth > prevHealth || _currHealth < prevHealth)
        {
            OnHealthChange?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion

    #region ProgressChangedEventTrigger
    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Progress Change
    public void ProgressChanged()
    {
        if (_currProgress > prevProgress || _currProgress < prevProgress)
        {
            OnProgressChange?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    void Awake()
    {
        timeHandler = FindObjectOfType<TimeHandler>();
    }

    void Start() { }

    #region Interface Functions
    public void Heal(float healAmount)
    {
        prevHealth = _currHealth;
        _currHealth += healAmount;
        if (_currHealth >= 100) _currHealth = 100;
    }

    public void Damage(float damageAmount)
    {
        prevHealth = _currHealth;
        _currHealth -= damageAmount;
        if (_currHealth <= 0) _currHealth = 0;
    }

    public void DOT(bool doDOT)
    {
        if (doDOT)
        {
            prevHealth = _currHealth;
            _currHealth -= dotDam * Time.deltaTime;
        }
        else
        {
            dotDam = 0;
        }
    }

    public void HOT(bool doHOT)
    {
        if (doHOT)
        {
            prevHealth = _currHealth;
            _currHealth += hotHeal * Time.deltaTime;
        }
        else
        {
            hotHeal = 0;
        }
    }

    public void ProgressIncrease(float increaseProgress, float cap)
    {
        prevProgress = _currProgress;
        _currProgress += increaseProgress;
        if (_currProgress >= cap) _currProgress = cap;
    }

    public void ProgressDecrease(float decreaseProgress)
    {
        prevProgress = _currProgress;
        _currProgress -= decreaseProgress;
        if (_currProgress <= 0) _currProgress = 0;
    }
    #endregion

    public void EnableBarrier()
    {
        barrier.SetActive(true);
        barrierDuration = 10f;
    }

    public void DisableBarrier()
    {
        barrier.SetActive(false);
    }

    void Update()
    {
        DOT(doDOT);
        HOT(doHOT);

        HealthChanged();
        ProgressChanged();

        if (barrier == null) return;
        if (barrier.activeInHierarchy && barrierDuration > 0)
        {
            barrierDuration -= Time.deltaTime;
        }
        else
        {
            DisableBarrier();
        }
    }
}