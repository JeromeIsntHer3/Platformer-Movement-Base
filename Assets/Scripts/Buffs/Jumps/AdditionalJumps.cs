using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Double Jump",menuName = "Buff/Double Jump")]
public class AdditionalJumps : Buff
{
    public int jumps;

    public override void Effect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = jumps;
    }

    public override void Over(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = 1;
    }
}