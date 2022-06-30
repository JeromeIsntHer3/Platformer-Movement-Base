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
    [Range(0.1f,0.2f)]private float jumpPressHeldBuffer;
    [SerializeField]
    private float jumpForce; 
    [SerializeField]
    private float decreasedGravScale;
    [SerializeField]
    private float baseGravScale;
    [SerializeField]
    private float increasedGravScale;
    [SerializeField]
    private float apexBoost;
    [SerializeField]
    private float jumpFallOff;
   
    //Component Variables
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCol;

    [Header("Jump Attributes")]
    //Jump Variables
    private float? lastGroundedTime;
    [SerializeField]
    private float coyotoTimeBuffer;
    private float jumpTimer;
    private bool isJumping;

    //Input Variables
    private Vector2 _moveInput;
    private bool jumpButtonPressed;
    private bool jumpButtonHeld;

    
    private bool _isFacingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();
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

    void JumpGrav()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = increasedGravScale;
        }
        else
        {
            rb.gravityScale = baseGravScale;
        }
    }

    bool IsGrounded()
    {
        float extraHeight = 1.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCol.bounds.center,capsuleCol.bounds.size 
            - new Vector3(0.1f, 1, 0), 0, Vector2.down, extraHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if (IsGrounded())
        {
            lastGroundedTime = Time.time;
        }
        if (jumpButtonPressed && Time.time - lastGroundedTime <= coyotoTimeBuffer)
        {
            isJumping = true;
            jumpTimer = jumpPressHeldBuffer;
        }
        if (jumpButtonHeld && isJumping)
        {
            if (jumpTimer > 0)
            {
                rb.gravityScale = decreasedGravScale;
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (!jumpButtonHeld)
        {
            isJumping = false;
        }
    }

    void ApexBoost()
    {
        if (!IsGrounded() && !isJumping && rb.velocity.y <= 0 && rb.velocity.y > -5)
        {
            if(_moveInput.x > 0)
            {
                rb.AddForce(transform.right * apexBoost * speed);
            }
            else if(_moveInput.x < 0)
            {
                rb.AddForce(transform.right * -apexBoost * speed);
            }
        }
    }

    void Update()
    {
        InputHandler();
        Jump();
        ApexBoost();
        JumpGrav();
    }

    void FixedUpdate()
    {
        Move(lerpAmount);
        if (_moveInput.x != 0)
        {
            CheckFaceDir(_moveInput.x < 0);
        }
    }


    #region Archive Sections
    //This Section of code was used in the past and was used due to misunderstanding
    //and lack of testing as well as perspective, feel free to implment the code
    //again if the situation requires them but they will not be of use and shall remain
    //commented out until they are required or refactored to fit the project

    //void ForcedGravity()
    //{
    //    if (!IsGrounded() && !isJumping)
    //    {
    //        rb.gravityScale = increasedGravScale;
    //        Debug.Log("Jump Cut");
    //    }
    //}

    //void BaseGravity()
    //{
    //    if (!IsGrounded() && !jumpButtonPressed && !jumpButtonHeld)
    //    {
    //        rb.gravityScale = baseGravScale;
    //    }
    //}
    #endregion
}