using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour
{
    public Dictionary<string, Buff> activeBfs = new Dictionary<string,Buff>();

    void Update()
    {
        foreach (var buff in activeBfs)
        {
            buff.Value.Effect(gameObject);
            if (buff.Value.cullDuration > 0)
            {
                buff.Value.cullDuration -= Time.deltaTime;
            }
            else
            {
                buff.Value.Over(gameObject);
                activeBfs.Remove(buff.Key);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Buff")
        {
            BuffObjectHolder buffHolder = other.GetComponent<BuffObjectHolder>();
            Buff newBuff = buffHolder.thisBuff;
            newBuff.cullDuration = newBuff.buffDuration;
            if (activeBfs.ContainsKey(newBuff.name))
            {
                newBuff.cullDuration += newBuff.cullDuration;
            }
            else
            {
                activeBfs.Add(newBuff.name, newBuff);
            }
            Destroy(other.gameObject);
        }
    }
}