using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : ScriptableObject
{
    public int id;
    public float buffDuration;
    public Sprite buffSprite;

    public virtual void Effect(GameObject parent) { }

    public virtual void EffectOver(GameObject parent) { }
}