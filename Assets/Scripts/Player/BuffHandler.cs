using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class BuffHandler : MonoBehaviour
{
    public List<BuffData> activeBuffList;
    private Buff buffObject;
    private BuffData ctxBuffData;

    private PlayerMovement pm;
    private Player player;

    private float activeTime;

    public event EventHandler BuffsOver;

    void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(ctxBuffData != null)BuffTimer();
        Debug.Log(ctxBuffData != null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Buff")
        {
            buffObject = other.GetComponent<Buff>();
            BuffData thisBuffData = buffObject.buffData;
            activeBuffList.Add(thisBuffData);
            SetupBuff(thisBuffData);
            Destroy(other.gameObject);
        }
    }

    void SetupBuff(BuffData currBuffData)
    {
        activeTime = currBuffData.activeTime;
        ctxBuffData = currBuffData;
        if(currBuffData.speedChange) pm.Speed = currBuffData.speed;
        if (currBuffData.jumpChange) pm.NoOfJumpsAllowed = currBuffData.jumps;
    }

    void BuffTimer()
    {
        if(activeTime > 0)
        {
            activeTime -= Time.deltaTime;
        }
        else
        {
            activeBuffList.Remove(ctxBuffData);
            ctxBuffData = null;
            BuffsOver?.Invoke(this, EventArgs.Empty);
        }
    }
}