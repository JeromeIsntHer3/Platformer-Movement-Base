using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public float damage;
    private bool patrol;
    private bool turn;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
        if (patrol)
        {
            turn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (turn)
        {
            TurnAround();
        }
        float topSpeedX = speed;
        topSpeedX = Mathf.Lerp(rb.velocity.x, topSpeedX, 0.5f);
        rb.velocity = new Vector2(topSpeedX, rb.velocity.y);
        rb.AddForce(transform.right * topSpeedX);
    }

    void TurnAround()
    {
        patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        patrol = true;
    }
}
