using UnityEngine.SceneManagement;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOver;

    [Header("Perspective UI")]
    [SerializeField]
    private GameObject reality;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private GameObject time;

    [Header("Cameras")]
    [SerializeField]
    private GameObject camera_1;
    [SerializeField]
    private GameObject camera_2;

    private PlayerInput playerInput;
    private bool swap;
    private GameHandler gameHandler;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        gameHandler = FindObjectOfType<GameHandler>();
    }

    void Update()
    {
        if (!gameHandler.gameOver)
        {
            if (Input.GetKeyDown(playerInput.swapKey))
            {
                SwapPerspective();
            }
            if (Input.GetKeyDown(playerInput.pauseKey))
            {
                gameHandler.PauseGame();
            }
        }
    }

    void SwapPerspective()
    {
        swap = !swap;
        if (!swap)
        {
            camera_1.SetActive(true);
            camera_2.SetActive(false);
            reality.SetActive(true);
            body.SetActive(false);
        }
        else
        {
            camera_1.SetActive(false);
            camera_2.SetActive(true);
            reality.SetActive(false);
            body.SetActive(true);
        }
    }

    #region General Functions
    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
    }

    public void GameOver()
    {
        SetAllOff();
        gameOver.SetActive(true);
    }

    void SetAllOff()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        reality.SetActive(false);
        body.SetActive(false);
        time.SetActive(false);
    }
    #endregion

    #region Pause Menu Functions
    public void Resume()
    {
        gameHandler.UnpauseGame();
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu_Demo");
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
    }
    #endregion

    #region Defeat/GameOver Functions
    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("In-Game_Demo");
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
    }
    #endregion
}