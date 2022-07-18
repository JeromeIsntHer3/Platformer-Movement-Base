using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, levelMenu;
    [SerializeField]
    private GameObject backButton;

    void Awake()
    {
        TurnOffAll();
        mainMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        TurnOffAll();
        mainMenu.SetActive(true);
    }

    public void PressPlay()
    {
        TurnOffAll();
        levelMenu.SetActive(true);
        backButton.SetActive(true);
    }

    void TurnOffAll()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        backButton.SetActive(false);
    }
}
