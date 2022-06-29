using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    private Player player;

    void Start()
    {
        SetHealth();
        healthBar = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.OnHealthChange += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(object sender, System.EventArgs e)
    {
        SetHealth();
    }

    public void SetHealth()
    {
        if(healthBar != null && player != null) healthBar.value = player.currHealth;
    }
}