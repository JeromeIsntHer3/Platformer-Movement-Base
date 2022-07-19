using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public class UIHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject settingsMenu;

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
    private bool gamePaused;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        if (TriggerZone.GameOver == false)
        {
            if (Input.GetKeyDown(playerInput.swapKey))
            {
                SwapPerspective();
            }
            if (Input.GetKeyDown(playerInput.pauseKey) && !gamePaused)
            {
                Pause();
            }
        }
        else
        {
            GameOver();
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
        Time.timeScale = 0;
        gamePaused = true;
        AnimateUI(pauseMenu,true,0.2f);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        gamePaused = false;
        AnimateUI(pauseMenu, false, 0.2f);
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
        Unpause();
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
    }

    public void Settings()
    {
        AnimateUI(settingsMenu, true, 0.3f);
        AnimateUI(pauseMenu, false, 0.3f);
    }

    public void BackToMenu()
    {
        AnimateUI(pauseMenu, true, 0.3f);
        AnimateUI(settingsMenu, false, 0.3f);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
        AnimateUI(pauseMenu, false, 0.3f,LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Menu_Demo");
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

    #region Animation Function
    void AnimateUI(GameObject go, bool active, float duration, Action func = null)
    {
        if (active)
        {
            StartCoroutine(WaitForAnimBefore(duration, go, func));
        }
        else
        {
            StartCoroutine(WaitForAnimAfter(duration, go, func));
        }
    }
    #endregion


    #region Coroutines
    IEnumerator WaitForAnimBefore(float time, GameObject go, Action func)
    {
        go.SetActive(true);
        go.transform.localScale = Vector2.zero;
        go.transform.LeanScale(Vector2.one, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        if (func != null) func();
    }
    IEnumerator WaitForAnimAfter(float time, GameObject go, Action func)
    {
        go.transform.LeanScale(Vector2.zero, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
        if(func != null) func();
    }
    #endregion
}