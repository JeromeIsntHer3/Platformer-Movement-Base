using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBuffHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject DisplayUISlotPrefab;
    [SerializeField]
    private Transform parentPanel;

    private MultiBuffHandler buffHandler;

    void Awake()
    {
        buffHandler = FindObjectOfType<MultiBuffHandler>();
    }

    public void NewBuffPickedUp(int index,string buffName, Sprite buffSprite)
    {
        GameObject temp = Instantiate(DisplayUISlotPrefab,parentPanel.localPosition,Quaternion.identity,parentPanel);
        DisplayBuffSlot newSlot = temp.GetComponent<DisplayBuffSlot>();
        if (newSlot)
        {
            newSlot.gameObject.name = buffName;
            newSlot.durationOverlay.sprite = buffSprite;
            newSlot.maxDuration = buffHandler.durationTimes[index];
        }
    }

    public void ExistingBuffPickedUp(string buffName,float additionalDuration)
    {
        if (parentPanel.Find(buffName))
        {
            parentPanel.Find(buffName).gameObject.GetComponent<DisplayBuffSlot>().currDuration += additionalDuration;
            parentPanel.Find(buffName).gameObject.GetComponent<DisplayBuffSlot>().maxDuration += additionalDuration;
        }
    }
}