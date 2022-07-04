using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour
{
    public Dictionary<string, Buff> activeBfs = new Dictionary<string,Buff>();
    public List<string> buffNames;
    public List<Buff> buffs;

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
        //foreach (string name in activeBfs.Keys)
        //{
        //    if (buffNames.Contains(name)) return;
        //    buffNames.Add(name.ToString());
        //}
        //foreach (Buff bff in activeBfs.Values)
        //{
        //    if (buffs.Contains(bff)) return;
        //    buffs.Add(bff);
        //}
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