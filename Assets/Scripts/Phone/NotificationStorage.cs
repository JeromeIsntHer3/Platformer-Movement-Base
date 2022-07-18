using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "App",menuName = "App/Notification Storage")]
public class NotificationStorage : ScriptableObject
{
    public List<NotificationData> notificationList;
}