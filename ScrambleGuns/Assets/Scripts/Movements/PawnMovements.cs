using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PawnMovements : MonoBehaviour
{
    public SO_MovementParms PawnAttributesSO;
    public Rigidbody rb;

    protected WaitForFixedUpdate waitFixed;

    protected bool moveTrue;
    protected bool jumpTrue = true;
    protected bool shootToStopMove = false;
    public UnityEvent PlayerHit;

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
            if (!shootToStopMove)
            {
                rb.MovePosition(transform.position + Vector3.left * (PawnAttributesSO.speed * Time.deltaTime));
            }
            yield return waitFixed;
        }
    }

    private IEnumerator MoveRight()
    {
        while (moveTrue)
        {
            if (!shootToStopMove)
            {
                rb.MovePosition(transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime));
            }
            yield return waitFixed;
        }
    }
    
    private IEnumerator MoveJump()
    {
        //Debug.Log("jumped");
        yield return new WaitForSeconds(2f);
        jumpTrue = true;
    }

    public void Shooting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shootToStopMove = true;
        }

        if (context.canceled)
        {
            shootToStopMove = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            PlayerHit.Invoke();
            //Debug.Log("HitPlayer");
        }
    }
}
