using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (progressBar != null && player != null) progressBar.value = player.currProgress;
    }
}