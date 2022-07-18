using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Boost", menuName = "Buff/Speed Boost")]
public class SpeedBoost : Buff
{
    public float newSpeed;

    public override void Effect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.Speed = newSpeed;
    }
    public override void EffectOver(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.Speed = 20;
    }
}