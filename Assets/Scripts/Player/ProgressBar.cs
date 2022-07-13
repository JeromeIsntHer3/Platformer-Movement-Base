using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar;
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player == null) return;
        progressBar = GetComponent<Slider>();
        SetProgress();
        player.OnProgressChange += Player_OnProgressChange;
    }

    private void Player_OnProgressChange(object sender, System.EventArgs e)
    {
        SetProgress();
    }
     
    void SetProgress()
    {
        if (progressBar != null && player != null) progressBar.value = player.CurrProgress;
    }
}