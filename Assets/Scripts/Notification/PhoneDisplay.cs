using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneDisplay : MonoBehaviour
{
    [SerializeField]
    private List<NotificationData> notifications;

    [SerializeField]
    private GameObject display;
    [SerializeField]
    private GameObject notificationPrefab;
    //[SerializeField]
    //private TextMeshProUGUI descriptionDisplay;

    private void OnEnable()
    {
        ClearSlots();
        SetUpNotifSlots();
    }

    //public void ClickOnDisplay(string desc)
    //{
    //    this.descriptionDisplay.text = desc;
    //}

    void SetUpNotifSlots()
    {
        if (display)
        {
            //for(int i = 0; i < notifications.Count; i++)
            //{
            //    GameObject temp = Instantiate(notificationPrefab, display.transform.position, Quaternion.identity, display.transform);
            //    temp.transform.SetParent(display.transform);
            //    NotificationSlot newSlot = temp.GetComponent<NotificationSlot>();
            //    if (newSlot)
            //    {
            //        newSlot.SetNotificationSlot(notifications[i],this);
            //    }
            //}
            foreach(NotificationData nd in notifications)
            {
                GameObject temp = Instantiate(notificationPrefab, display.transform.position, Quaternion.identity, display.transform);
                temp.transform.SetParent(display.transform);
                NotificationSlot newSlot = temp.GetComponent<NotificationSlot>();
                if (newSlot)
                {
                    newSlot.SetNotificationSlot(nd, nd.header,this);
                }
            }
        }
    }

    void ClearSlots()
    {
        if (display)
        {
            for(int i = 0; i < display.transform.childCount; i++)
            {
                Destroy(display.transform.GetChild(i).gameObject);
            }
        }
    }
}
