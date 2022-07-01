using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Player : MonoBehaviour, HealthInterfaces, ProgressInterfaces
{
    [Header("Set Health and Progress")]
    [SerializeField]
    private float _currHealth;
    [SerializeField]
    private float _currProgress;

    [HideInInspector]
    public float currHealth { get { return _currHealth; } }
    [HideInInspector]
    public float currProgress { get { return _currProgress; } }

    private float dot;
    private float hot;

    [Header("Cycles")]
    [SerializeField]
    private float timeCycle;
    [SerializeField]
    private float internalTimeCycle;

    [Header("Displays")]
    [SerializeField]
    private TextMeshProUGUI timeDisplay;
    [SerializeField]
    private TextMeshProUGUI internalTimeDisplay;

    private float prevHealth;
    private float prevProgress;

    public TimeCheckSystem tcs;
    
    //Events for Changes In Health & Progress
    //This Events run and are used in HealthChanged
    //and ProgressChanged
    public event EventHandler OnHealthChange, OnProgressChange, OnPickedUp;

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
        tcs = new TimeCheckSystem();
        tcs.SetCycleAndDisplay(timeCycle, internalTimeCycle, timeDisplay, internalTimeDisplay);
        OnPickedUp += OnPickedUpEvent;
    }

    private void OnPickedUpEvent(object sender, EventArgs e)
    {
    }

    void Start()
    {
        tcs.TCSStart();
    }

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

    public void DOT()
    {
        prevHealth = _currHealth;
        _currHealth -= dot * Time.deltaTime;
    }

    public void HOT()
    {
        prevHealth = _currHealth;
        _currHealth += hot * Time.deltaTime;
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

    void Update()
    {
        HealthChanged();
        ProgressChanged();
        tcs.TCSUpdate();
    }

    //To Interact With Pills
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pill")
        {
            Pill thisPill = other.GetComponent<Pill>();
            if (thisPill != null)
            {
                ProgressIncrease(thisPill.progressAmount, thisPill.progressCap);
                OnPickedUp?.Invoke(this, EventArgs.Empty);
                Destroy(thisPill.gameObject, 0.1f);
            }
        }

        if(other.tag == "Buff")
        {
            BaseBuff thisBuff = other.GetComponent<BaseBuff>();
            if(thisBuff != null)
            {
                thisBuff.Effect(gameObject);
                Destroy(thisBuff, 0.1f);
            }
        }
    }
}