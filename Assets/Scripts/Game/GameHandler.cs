using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private UIHandler uiHandler;
    [HideInInspector]
    public bool gameOver;

    void Awake()
    {
        uiHandler = FindObjectOfType<UIHandler>();
        Time.timeScale = 1;
        gameOver = false;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        uiHandler.Unpause();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        uiHandler.Pause();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        uiHandler.GameOver();
    }
}