using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movementInput { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool jumpHeld { get; private set; }
    public bool jumpReleased { get; private set; }

    public KeyCode jumpKey;
    public KeyCode pauseKey;
    public KeyCode swapKey;

    void Update()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        jumpPressed = Input.GetKeyDown(jumpKey);
        jumpHeld = Input.GetKey(jumpKey);
        jumpReleased = Input.GetKeyUp(jumpKey);
    }
}