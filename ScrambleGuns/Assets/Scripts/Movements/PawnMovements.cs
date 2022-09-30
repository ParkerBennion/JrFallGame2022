using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PawnMovements : MonoBehaviour
{
    public SO_MovementParms PawnAttributesSO;
    public Rigidbody rb;

    private WaitForFixedUpdate waitFixed;

    private bool moveTrue;
    private bool jumpTrue = true;

    private void Start()
    {
    }

    public void MovePositoinLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveTrue = true;
            StartCoroutine(MoveLeft());
        }
        if (context.canceled)
        {
            moveTrue = false;
        }
        
    }
    public void MovePositoinRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveTrue = true;
            StartCoroutine(MoveRight());
        }
        if (context.canceled)
        {
            moveTrue = false;
        }
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpTrue)
        {
            jumpTrue = false;
            StartCoroutine(MoveJump());
        }
    }

    
    private IEnumerator MoveLeft()
    {
        while (moveTrue)
        {
            rb.MovePosition(transform.position + Vector3.left * (PawnAttributesSO.speed * Time.deltaTime));
            yield return waitFixed;
        }
    }

    private IEnumerator MoveRight()
    {
        while (moveTrue)
        {
            rb.MovePosition(transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime));
            yield return waitFixed;
        }
    }
    
    private IEnumerator MoveJump()
    {
        
        Debug.Log("jumped");
        yield return new WaitForSeconds(2f);
        jumpTrue = true;
        
    }
}
