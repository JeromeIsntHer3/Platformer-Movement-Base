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
            player.EnableBarrier();
            player.DoDOT = false;
            float currTime = player.timeHandler.TimeCountDown;
            if (5 > currTime && currTime > 0)
            {
                player.ProgressIncrease(thisProgressAmount, thisProgressCap);
                player.Heal(thisHealAmount);
            }
            else if (15 > currTime && currTime > 5)
            {
                player.ProgressIncrease(thisProgressAmount/2, thisProgressCap);
                player.Heal(thisHealAmount/2);
            }
            else
            {
                player.Damage(10);
            }
            Destroy(gameObject);
        }
    }
}