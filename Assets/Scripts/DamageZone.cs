using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public enum Type
    {
        heal,damage
    }

    public Type typeOfBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthInterfaces otherObj  = other.GetComponent<HealthInterfaces>();
        if(typeOfBox == Type.damage)otherObj.Damage();
        if (typeOfBox == Type.heal) otherObj.Heal();
    }
}