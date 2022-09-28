using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private PlayerControlls playerControlls;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
        playerControlls.Basic.Move.started += Move;
        
        playerControlls.Basic.Move.performed += Move;
        
        playerControlls.Basic.Move.canceled += Move;
    }

    private void OnDisable()
    {
        playerControlls.Disable();
        playerControlls.Basic.Move.started -= Move;
    }

    private void Start()
    {
        playerControlls.Basic.Move.started += Move;
        
        playerControlls.Basic.Move.performed += Move;
        
        playerControlls.Basic.Move.canceled += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("moving");
        context.ReadValue<Vector2>();
    }
    // private void Update()
    // {
    //     Vector2 move = playerControlls.Basic.Move.ReadValue<Vector2>();
    //     Debug.Log(move);
    //     
    //     if (playerControlls.Basic.Jump.triggered)
    //     {
    //         Debug.Log("jump");
    //     }
    // }
}
