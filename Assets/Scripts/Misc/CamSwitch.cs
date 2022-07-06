using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject ui1;
    public GameObject ui2;
    private bool swapped;

    private void Awake()
    {
        ui2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            swapped = !swapped;
            if (!swapped)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            else
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            if (!swapped)
            {
                ui1.SetActive(true);
                ui2.SetActive(false);
            }
            else
            {
                ui1.SetActive(false);
                ui2.SetActive(true);
            }
        }
    }
}