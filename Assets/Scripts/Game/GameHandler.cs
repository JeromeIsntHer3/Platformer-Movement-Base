using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private Player player;
    private PlayerInput playerInput;

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject[] toRemove;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerInput = FindObjectOfType<PlayerInput>();
        gameOverText.SetActive(false);
        menu.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayLoop(SoundManager.Instance.music[0]);
    }

    public bool IsGameOver()
    {
        bool gameOver = false;
        if (!player) gameOver = true;
        return gameOver;
    }

    void Update()
    {
        if (IsGameOver())
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            foreach(GameObject go in toRemove)
            {
                go.SetActive(false);
            }
        }

        if (Input.GetKeyDown(playerInput.pauseKey))
        {
            if (!menu.activeInHierarchy)
            {
                menu.SetActive(true);
            }
        }
    }
}