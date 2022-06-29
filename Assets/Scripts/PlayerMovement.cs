using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Check")]
    public LayerMask groundLayerMask;

    [Header("Movement Attributes")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lerpAmount = 1f;

    [Header("Jump Attributes")]
    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float normalGravScale;
    [SerializeField]
    private float increasedGravScale;
    [SerializeField]
    private float apexBoost;

    private bool _isFacingRight;
   
    //Component Variables
    private Rigidbody2D rb;
    private CircleCollider2D circleCol;

    private float jumpTimer;
    private bool isJumping;

    //Time Variables
    private float lastTimeGrounded;
    private float coyotoTimeBuffer;
    

    //Input Variables
    private Vector2 _moveInput;
    private bool jumpButtonPressed;
    private bool jumpButtonHeld;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
    }

    void InputHandler()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        jumpButtonPressed = Input.GetKeyDown(KeyCode.Space);
        jumpButtonHeld = Input.GetKey(KeyCode.Space);
    }

    void Move(float lerpAmount)
    {
        float topSpeedX = speed * _moveInput.x;
        //if (lerpAmount < 1) lerpAmount *= 0.2f;
        topSpeedX = Mathf.Lerp(rb.velocity.x, topSpeedX, lerpAmount);
        rb.velocity = new Vector2(topSpeedX, rb.velocity.y);
    }

    void CheckFaceDir(bool isMovingRight)
    {
        if (isMovingRight != _isFacingRight)
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        _isFacingRight = !_isFacingRight;
    }

    void Jump()
    {
        if (jumpButtonPressed && isGrounded())
        {
            rb.gravityScale = normalGravScale;
            isJumping = true;
            jumpTimer = jumpTime;
        }
        if (jumpButtonHeld && isJumping)
        {
            if (jumpTimer > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (!jumpButtonHeld) isJumping = false;
    }

    void ForcedGravity()
    {
        if (!isGrounded() && !isJumping)
        {
            rb.gravityScale = increasedGravScale;
        }
    }

    bool isGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(circleCol.bounds.center,
            circleCol.bounds.size - new Vector3(0.1f, 0, 0), 0, Vector2.down, extraHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    void ApexBoost()
    {
        if (!isGrounded() && !isJumping)
        {
            if(_moveInput.x > 0)
            {
                rb.AddForce(transform.right * apexBoost);
                Debug.Log(rb.velocity.x);
            }
            else if(_moveInput.x < 0)
            {
                rb.AddForce(transform.right * -apexBoost);
                Debug.Log("Apex Boost Left");
            }
        }
    }

    void Update()
    {
        InputHandler();
        Jump();
        ApexBoost();
        ForcedGravity();
    }

    void FixedUpdate()
    {
        Move(lerpAmount);
        if (_moveInput.x != 0)
        {
            CheckFaceDir(_moveInput.x < 0);
        }
    }
}