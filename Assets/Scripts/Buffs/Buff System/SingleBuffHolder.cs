using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBuffHolder : MonoBehaviour
{
    public Buff currBuff;

    float durationTime;

    void Update()
    {
        if (currBuff == null) return;
        if (durationTime > 0)
        {
            durationTime -= Time.deltaTime;
            currBuff.Effect(gameObject);
        }
        else
        {
            currBuff.EffectOver(gameObject);
            currBuff = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Buff")
        {
            Debug.Log(other.GetComponent<GameObjectBuffHolder>().thisBuff);
            currBuff = other.GetComponent<GameObjectBuffHolder>().thisBuff;
            durationTime = currBuff.buffDuration;
            Destroy(other.gameObject);
        }
    }
}