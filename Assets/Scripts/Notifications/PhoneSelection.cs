using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSelection : MonoBehaviour
{
    public GameObject phone, main, app1, app2, app3, app4, exit;

    private void Awake()
    {
        phone.SetActive(false);
        main.SetActive(true);
    }

    public void OnClickPhoneIcon()
    {
        if (phone.activeInHierarchy)
        {
            phone.SetActive(false);
        }
        else
        {
            phone.SetActive(true);
        }
    }

    public void OnClickExit()
    {
        phone.SetActive(false);
    }

    public void OnClickApp1()
    {
        OffAll();
        app1.SetActive(true);
    }

    public void OnClickApp2()
    {
        OffAll();
        app2.SetActive(true);
    }

    public void OnClickApp3()
    {
        OffAll();
        app3.SetActive(true);
    }

    public void OnClickApp4()
    {
        OffAll();
        app4.SetActive(true);
    }

    public void BackToMain()
    {
        OffAll();
        main.SetActive(true);
        exit.SetActive(true);
    }

    void OffAll()
    {
        main.SetActive(false);
        app1.SetActive(false);
        app2.SetActive(false);
        app3.SetActive(false);
        app4.SetActive(false);
        exit.SetActive(false);
    }
}