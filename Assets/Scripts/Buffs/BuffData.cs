using UnityEngine;

[CreateAssetMenu(fileName = "Buff",menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public float activeTime;
    public float speed;
    public int jumps;

    public bool speedChange, jumpChange;
}