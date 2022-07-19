using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBuffHandler : MonoBehaviour
{
    private Buff collectedBuff;
    private DisplayBuffHandler displayBuffHandler;

    public List<int> ids;

    public List<Buff> activeBuffs;

    public List<float> durationTimes;

    void Awake()
    {
        displayBuffHandler = FindObjectOfType<DisplayBuffHandler>();
    }

    void Update()
    {
        DecrementDuration();
    }

    private void DecrementDuration()
    {
        for (int i = durationTimes.Count - 1; i >= 0; i--)
        {
            if (durationTimes[i] > 0) durationTimes[i] -= Time.deltaTime;
            if (durationTimes[i] <= 0)
            {
                ids.RemoveAt(i);
                durationTimes.RemoveAt(i);
                activeBuffs[i].EffectOver(gameObject);
                activeBuffs.RemoveAt(i);
            }
        }
        foreach (Buff buff in activeBuffs)
        {
            if (!buff) return;
            buff.Effect(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Buff")
        {
            collectedBuff = other.GetComponent<GameObjectBuffHolder>().thisBuff;
            if (ids.Contains(collectedBuff.id))
            {
                int index = ids.IndexOf(collectedBuff.id);
                durationTimes[index] += collectedBuff.buffDuration;
                displayBuffHandler.ExistingBuffPickedUp(collectedBuff.name,collectedBuff.buffDuration);
            }
            else
            {
                ids.Add(collectedBuff.id);
                activeBuffs.Add(collectedBuff);
                durationTimes.Add(collectedBuff.buffDuration);
                displayBuffHandler.NewBuffPickedUp(durationTimes.IndexOf(collectedBuff.buffDuration),
                    collectedBuff.name,collectedBuff.buffSprite);

                collectedBuff = null;
            }
            Destroy(other.gameObject);
        }
    }
}