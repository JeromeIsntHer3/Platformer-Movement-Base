using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    private GameObject parent;

    private void Awake()
    {
        parent = GetComponentInParent<Enemy>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(parent);
        }
    }
}