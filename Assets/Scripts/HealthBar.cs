using System.Collections;
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
    }

    public void SetHealth()
    {
        if(healthBar != null && player != null) healthBar.value = player.currHealth;
    }
}