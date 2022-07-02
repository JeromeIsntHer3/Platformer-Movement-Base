using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField]
    private float thisHealAmount;
    [SerializeField]
    private float thisProgressAmount;
    [SerializeField]
    private float thisProgressCap;

    private SpriteRenderer sr;

    private enum ColorType
    {
        Red,Green,Blue
    }

    [SerializeField]
    private ColorType colourType;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        switch (colourType)
        {
            case ColorType.Red:
                sr.color = Color.red;
                break;
            case ColorType.Green:
                sr.color = Color.green;
                break;
            case ColorType.Blue:
                sr.color = Color.blue;
                break;
            default:
                break;
        }
    }

    public float HealAmount { get { return thisHealAmount; } }
    public float ProgressAmount {get {return thisProgressAmount; } }
    public float ProgressCap { get { return thisProgressCap; } }
}