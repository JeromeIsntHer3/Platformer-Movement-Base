using UnityEngine;

public class AppDisplay : MonoBehaviour
{
    [SerializeField]
    private NotificationStorage notificationStorage;

    [SerializeField]
    private GameObject display;
    [SerializeField]
    private GameObject notificationPrefab;

    private void OnEnable()
    {
        ClearSlots();
        SetUpSlots();
    }

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
                    newSlot.SetNotificationSlot(notification);
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
