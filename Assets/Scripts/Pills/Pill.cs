using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField]
    private float thisHealAmount;
    [SerializeField]
    private float thisProgressAmount;
    [SerializeField]
    private float thisProgressCap;

    public float healAmount { get { return thisHealAmount; } }
    public float progressAmount {get {return thisProgressAmount; } }
    public float progressCap { get { return thisProgressCap; } }
}