using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction moveAction;
    public Vector2 movementDirection;
    public float playerSpeed = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        moveAction = playerInput.actions["Move"];
        Debug.Log("Player input registered" + playerInput);
        Debug.Log("Move action registered" + moveAction);
    }

    private void Update()
    {
        movementDirection = moveAction.ReadValue<Vector2>();
        Debug.Log("Movement Direction" + movementDirection);
        rb.linearVelocity = movementDirection * playerSpeed;
    }
}
