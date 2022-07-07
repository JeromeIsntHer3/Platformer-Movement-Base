using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField]
    private float thisHealAmount;
    [SerializeField]
    private float thisProgressAmount;
    [SerializeField]
    private float thisProgressCap;

    private Player player;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.ProgressIncrease(thisProgressAmount, thisProgressCap);
            player.Heal(thisHealAmount);
            player.EnableBarrier();
            player.DoDOT = false;
            Destroy(gameObject, 0.1f);
        }
    }
}