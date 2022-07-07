using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject[] toRemove;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        gameOver.SetActive(false);
    }

    void Update()
    {
        if (!player)
        {
            gameOver.SetActive(true);
            foreach(GameObject go in toRemove)
            {
                go.SetActive(false);
            }
        }
    }
}