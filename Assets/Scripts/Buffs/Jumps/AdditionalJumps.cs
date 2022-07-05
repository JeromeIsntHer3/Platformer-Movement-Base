using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Additional Jump",menuName = "Buff/Jumps")]
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