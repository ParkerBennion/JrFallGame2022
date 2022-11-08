using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PawnMovements
{
    private WaitForSeconds fireTime;
    public GameObject cursor;
    private bool cursorMove= false;
    private Coroutine leftmove = null;
    private Coroutine rightmove = null;
    private Coroutine upmove = null;
    private Coroutine downmove = null;
    public GameObject leftBound,rightBound;
    private void Awake()
    {
        fireTime = new WaitForSeconds(PawnAttributesSO.fireRate);
    }

    public void StartShooting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PawnAttributesSO.canShoot = true;
            StartCoroutine(shooting());
        }
        if (context.canceled)
        {
            PawnAttributesSO.canShoot = false;
            StopCoroutine(shooting());
        }
    }

    IEnumerator shooting()
    {
        while (PawnAttributesSO.canShoot)
        {
            Instantiate(PawnAttributesSO.bulletFab);
            yield return fireTime;
        }
    }
    
    public void MoveCursorUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cursorMove = true;
            upmove = StartCoroutine(MoveCursorUp());
        }

        if (context.canceled)
        {
            StopCoroutine(upmove);
        }
    }
    
    public void MoveCursorDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cursorMove = true;
            downmove = StartCoroutine(MoveCursorDown());
        }

        if (context.canceled)
        {
            StopCoroutine(downmove);
        }
    }
    
    public void MoveCursorLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cursorMove = true;
            leftmove = StartCoroutine(MoveCursorLeft());
        }

        if (context.canceled)
        {
            StopCoroutine(leftmove);
        }
    }
    
    public void MoveCursorRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cursorMove = true;
            rightmove = StartCoroutine(MoveCursorRight());
        }

        if (context.canceled)
        {
            StopCoroutine(rightmove);
        }
    }
    private IEnumerator MoveCursorUp()
    {
        while (cursorMove)
        {
            if (cursor.transform.position.y !<= 4.45)
            {
                cursor.transform.Translate(Vector3.up * (PawnAttributesSO.speed* 1.5f * Time.deltaTime));
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorDown()
    {
        while (cursorMove)
        {
            if (cursor.transform.position.y !>= -5.1)
            {
                cursor.transform.Translate(Vector3.down * (PawnAttributesSO.speed * 1.5f * Time.deltaTime));;
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorLeft()
    {
        while (cursorMove)
        {
            if (cursor.transform.position.x >= leftBound.transform.position.x)
            {
                cursor.transform.Translate(Vector3.left * (PawnAttributesSO.speed * 2f * Time.deltaTime));;
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorRight()
    {
        while (cursorMove)
        {
            if (cursor.transform.position.x <= rightBound.transform.position.x)
            {
                cursor.transform.Translate(Vector3.right * (PawnAttributesSO.speed * 2f * Time.deltaTime));;
            }
            yield return waitFixed;
        }
    }

    public void DiveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //rb.transform.position = Vector3.left*2;
            rb.transform.Translate(Vector3.left);
            //Debug.Log("diveLeft");
        }
    }
    public void DiveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //rb.transform.position = Vector3.right*2;
            rb.transform.Translate(Vector3.right);
            //Debug.Log("diveRight");
        }
    }
}
