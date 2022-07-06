using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneDisplay : MonoBehaviour
{
    [SerializeField]
    private NotificationStorage notificationStorage;

    [SerializeField]
    private GameObject display;
    [SerializeField]
    private GameObject notificationPrefab;
    //[SerializeField]
    //private TextMeshProUGUI descriptionDisplay;

    private void OnEnable()
    {
        ClearSlots();
        SetUpSlots();
    }

    //public void ClickOnDisplay(string desc)
    //{
    //    this.descriptionDisplay.text = desc;
    //}

    void SetUpSlots()
    {
        if (display)
        {
            foreach(NotificationData notification in notificationStorage.notificationList)
            {
                GameObject temp = Instantiate(notificationPrefab, display.transform.position, Quaternion.identity, display.transform);
                temp.transform.SetParent(display.transform);
                NotificationSlot newSlot = temp.GetComponent<NotificationSlot>();
                if (newSlot)
                {
                    newSlot.SetNotificationSlot(notification, this);
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
