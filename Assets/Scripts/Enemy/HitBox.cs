using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private Enemy parent;

    private void Awake()
    {
        parent = GetComponentInParent<Enemy>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage(parent.damage);
        }
    }
}
