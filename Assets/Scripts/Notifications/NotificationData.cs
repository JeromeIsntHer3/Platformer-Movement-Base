using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Notification",menuName ="Notification/Notification Data")]
public class NotificationData : ScriptableObject
{
    public string header;
    public string info;
    public Color color;
}