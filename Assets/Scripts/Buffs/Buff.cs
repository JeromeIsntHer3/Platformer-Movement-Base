using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : ScriptableObject
{
    public float buffDuration;
    public float cullDuration;
    protected bool affected;

    public virtual void Effect(GameObject parent) { }

    public virtual void Over(GameObject parent) { }
}