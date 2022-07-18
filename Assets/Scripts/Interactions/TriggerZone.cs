using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    public enum Type
    {
        heal, damage, death, popup
    }

    //Set the type of triggerzone this is
    public Type typeOfBox;

    //set damage/heal healAndDamageAmount in inspector for this object
    [SerializeField]
    private float healAndDamageAmount;

    [SerializeField]
    private PopUp popup;
    [SerializeField]
    private float popupTime;
    [SerializeField]
    [Multiline]
    private string popupInfo;
    [SerializeField]
    private Color popupBGColor;

    public static bool GameOver;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthInterfaces otherObj  = other.GetComponent<HealthInterfaces>();

        if (typeOfBox == Type.damage) otherObj.Damage(healAndDamageAmount);
        if (typeOfBox == Type.heal) otherObj.Heal(healAndDamageAmount);
        if (typeOfBox == Type.death)
        {
            if (other.gameObject != null) Destroy(other.gameObject);
            if (other.tag == "Player")
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.DieSound);
                GameOver = true;
            }
        }
        if(typeOfBox == Type.popup)
        {
            if(other.tag == "Player")
            {
                StartCoroutine(PopUp());    
            }
        }
    }

    IEnumerator PopUp()
    {
        popup.gameObject.SetActive(true);
        popup.SetText(popupInfo,popupBGColor);
        yield return new WaitForSeconds(popupTime);
        popup.gameObject.SetActive(false);
    }
}