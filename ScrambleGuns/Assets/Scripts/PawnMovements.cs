using UnityEngine;
using UnityEngine.InputSystem;

public class PawnMovements : MonoBehaviour
{
    public SO_MovementParms PawnAttributesSO;
    public Rigidbody2D rb;

    public PlayerControlls playerControls;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerControlls();
    }

    private void OnEnable()
    {
        move = playerControls.Basic.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * (PawnAttributesSO.speed)*-1, moveDirection.y * PawnAttributesSO.speed);
    }
}
