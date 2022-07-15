using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    //Component Variables
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCol;
    private PlayerInput playerInput;

    [Header("Movement Attributes")]
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
    [SerializeField]
    private float lerpAmount = 1f;

    [Header("Jump Attributes")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float baseGravScale;
    [SerializeField]
    private float increasedGravScale;
    [SerializeField]
    private float apexBoost;
    [SerializeField]
    private float jumpFallOffAtApex;
    [SerializeField]
    private float coyotoTimeBuffer;
    private int noOfJumpsAllowed;
    public int NoOfJumpsAllowed { get { return noOfJumpsAllowed; } set { noOfJumpsAllowed = value; } }
    private int noOfJumps;
    private float? lastGroundedTime;

    [Header("Ground Check")]
    public LayerMask groundLayerMask;

    private bool _isFacingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Move()
    {
        float topSpeedX = speed * playerInput.movementInput.x;
        topSpeedX = Mathf.Lerp(rb.velocity.x, topSpeedX, lerpAmount);
        rb.velocity = new Vector2(topSpeedX, rb.velocity.y);
        rb.AddForce(transform.right * topSpeedX);
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

    void Gravity()
    {
        if (rb.velocity.y < 0)
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
        float extraHeight = 0.7f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCol.bounds.center, capsuleCol.bounds.size
            - new Vector3(0.1f, 1, 0), 0, Vector2.down, extraHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if (IsGrounded())
        {
            lastGroundedTime = Time.time;
            noOfJumps = noOfJumpsAllowed;
        }
        if (playerInput.jumpPressed)
        {
            if (CoyoteJumpPossible())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SoundManager.Instance.PlaySound(SoundManager.Instance.JumpSound);
            }
            else if (noOfJumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        if (playerInput.jumpReleased)
        {
            noOfJumps -= 1;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / jumpFallOffAtApex);
            }
        }
    }

    void ApexBoost()
    {
        if (-10 < rb.velocity.y && rb.velocity.y <= -0.01)
        {
            if (playerInput.movementInput.x > 0)
            {
                rb.AddForce(transform.right * apexBoost);
            }
            else if (playerInput.movementInput.x < 0)
            {
                rb.AddForce(transform.right * -apexBoost);
            }
        }
    }

    bool CoyoteJumpPossible()
    {
        return Time.time - lastGroundedTime <= coyotoTimeBuffer;
    }

    void Update()
    {
        ApexBoost();
        Jump();
        Gravity();
    }

    void FixedUpdate()
    {
        Move();
        if (playerInput.movementInput.x != 0)
        {
            CheckFaceDir(playerInput.movementInput.x < 0);
        }
    }

    #region Archive Sections
    //This Section of code was used in the past and was used due to misunderstanding
    //and lack of testing as well as perspective, feel free to implment the code
    //again if the situation requires them but they will not be of use and shall remain
    //commented out until they are required or refactored to fit the project
    //void Jump()
    //{
    //    if (IsGrounded())
    //    {
    //        lastGroundedTime = Time.time;
    //        numberOfJumps = NoOfJumpsAllowed;
    //    }
    //    if (playerInput.jumpPressed && CoyoteTime() && numberOfJumps > 0)
    //    {
    //        isJumping = true;
    //        jumpTimer = jumpPressHeldBuffer;
    //        rb.velocity = Vector2.up * jumpForce;
    //        numberOfJumps -= 1;
    //    }
    //    if (playerInput.jumpHeld && isJumping)
    //    {
    //        if (jumpTimer > 0)
    //        {
    //            rb.gravityScale = decreasedGravScale;
    //            rb.velocity = Vector2.up * jumpForce;
    //            jumpTimer -= Time.deltaTime;
    //        }
    //        else
    //        {
    //            isJumping = false;
    //        }
    //    }
    //    if (!playerInput.jumpHeld)
    //    {
    //        if (numberOfJumps == 0)
    //        {
    //            isJumping = false;
    //        }
    //    }
    //}

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