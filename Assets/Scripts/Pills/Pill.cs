using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public PillData thisPill;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.ProgressIncrease(thisPill.progressAmount, thisPill.cap);
            Destroy(gameObject, 0.1f);
        }
    }
}