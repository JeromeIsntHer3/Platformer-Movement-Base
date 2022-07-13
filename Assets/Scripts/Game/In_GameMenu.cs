using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class In_GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void Resume()
    {
        menu.SetActive(false);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu_Demo");
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayLoop(SoundManager.Instance.music[1]);
    }
}