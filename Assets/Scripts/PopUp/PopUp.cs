using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "PopUp",menuName = "Messages/PopUps")]
public class PopUp : ScriptableObject
{
    [Multiline]
    public string popUpText;
    public Color backgroundColor;
    public float popUpTime;
}