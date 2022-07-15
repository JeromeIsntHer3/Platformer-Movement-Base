using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationSlot : MonoBehaviour
{
    NotificationData thisNotification;
    public TextMeshProUGUI thisHeader;
    public TextMeshProUGUI thisInfo;
    public Image thisImage;

    public void SetNotificationSlot(NotificationData newNotification)
    {
        thisNotification = newNotification;
        if (thisNotification)
        {
            thisImage.color = thisNotification.color;
            thisHeader.text = thisNotification.header;
            thisInfo.text = thisNotification.info;
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
