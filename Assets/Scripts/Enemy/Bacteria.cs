using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    private float distToPlayer;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private SoundManager soundManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().transform;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (player == null) return;

        //Lazy Method
        //if(DistToPlayer() < range)
        //{ 
        //    rb.transform.position = Vector2.Lerp(transform.position, player.position, speed);
        //}
        //else
        //{
        //    rb.velocity = new Vector2(0, 0); 
        //}
        //Diff Method
        if (DistToPlayer() < range)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDir = direction;
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    float DistToPlayer()
    {
        distToPlayer = Vector3.Distance(transform.position, player.position);
        return distToPlayer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.HitSound);
            Player player = other.GetComponent<Player>();
            player.DOTDam = damage;
            player.DoDOT = true;
            Destroy(gameObject);
        }
    }
}
