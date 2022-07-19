using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI popUpText;
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject popUp;

    private float popUpTime;

    void Awake()
    {
        popUp.SetActive(false);
    }

    public void SetUpPopUp(PopUp currPopUp)
    {
        popUpText.text = currPopUp.popUpText;
        background.color = currPopUp.backgroundColor;
        popUpTime = currPopUp.popUpTime;
        popUp.SetActive(true);
        if (popUpTime > 0)
        {
            StartCoroutine(TurnOff());
        }
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(popUpTime);
        gameObject.SetActive(false);
    }
}