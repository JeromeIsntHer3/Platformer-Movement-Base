using UnityEngine;

[CreateAssetMenu(fileName = "PillData", menuName = "Data/PillData")]
public class PillData : ScriptableObject
{
    public float healAmount;
    public float progressAmount;
    public float cap;
}