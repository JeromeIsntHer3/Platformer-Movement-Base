using UnityEngine;

public class MoreJumps : BaseBuff
{
    public float jumps;

    public override void Effect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        
    }
}
