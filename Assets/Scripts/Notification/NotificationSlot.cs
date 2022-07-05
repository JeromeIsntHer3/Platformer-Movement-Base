using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationSlot : MonoBehaviour
{
    NotificationData thisNotification;
    PhoneDisplay thisDisplay;
    public TextMeshProUGUI thisHeader;

    public Color thisColor;

    public void SetNotificationSlot(NotificationData newNotification,string header, PhoneDisplay display)
    {
        thisNotification = newNotification;
        thisDisplay = display;
        thisHeader.text = header;
        if (thisNotification)
        {
            thisColor = thisNotification.color;
        }
    }

    //public void OnClicked()
    //{
    //    if (thisNotification)
    //    {
    //        thisDisplay.ClickOnDisplay(thisNotification.header);
    //    }
    //}
}
