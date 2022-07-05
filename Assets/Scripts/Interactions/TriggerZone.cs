using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    //set damage/heal amount in inspector for this object
    [SerializeField]
    private float amount;

    public enum Type
    {
        heal,damage,death
    }

    //Set the type of triggerzone this is
    public Type typeOfBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthInterfaces otherObj  = other.GetComponent<HealthInterfaces>();

        if (typeOfBox == Type.damage) otherObj.Damage(amount);
        if (typeOfBox == Type.heal) otherObj.Heal(amount);
        if (typeOfBox == Type.death) Destroy(other.gameObject);
    }
}