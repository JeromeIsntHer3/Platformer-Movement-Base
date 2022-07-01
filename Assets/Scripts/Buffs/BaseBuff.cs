using UnityEngine;

public class BaseBuff : MonoBehaviour
{
    public string buffName;
    public float activeTime;

    public virtual void Effect(GameObject parent){}
}