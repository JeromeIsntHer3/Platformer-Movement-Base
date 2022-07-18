using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : ScriptableObject
{
    public int id;
    public float buffDuration;

    [HideInInspector]
    public float cullDuration;

    public virtual void Effect(GameObject parent) { }

    public virtual void EffectOver(GameObject parent) { }
}