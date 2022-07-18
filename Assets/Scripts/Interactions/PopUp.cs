using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI popupText;
    [SerializeField]
    private Image popupBackground;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string popupInfo, Color background)
    {
        popupText.text = popupInfo;
        popupBackground.color = background;
    }
}