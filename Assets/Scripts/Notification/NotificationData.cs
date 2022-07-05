using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Notification",menuName ="Notifications/Notification")]
public class NotificationData : ScriptableObject
{
    public string header;
    public Sprite sprite;
    public Color color;
}