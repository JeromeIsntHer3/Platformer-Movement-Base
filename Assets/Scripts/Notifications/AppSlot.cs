using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppSlot : MonoBehaviour
{
    [SerializeField]
    private NotificationData thisAppSlot;
    [SerializeField]
    private TextMeshProUGUI thisAppName;
    [SerializeField]
    private Image thisAppImage;

    private void OnEnable()
    {
        thisAppName.text = thisAppSlot.header;
        thisAppImage.color = thisAppSlot.color;
    }
}