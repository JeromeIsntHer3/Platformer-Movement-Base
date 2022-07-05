using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : ScriptableObject
{
    public float buffDuration;
    [HideInInspector]
    public float cullDuration;

    public virtual void Effect(GameObject parent) { }

    public virtual void Over(GameObject parent) { }
}