using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PawnMovements
{
    private WaitForSeconds fireTime;
    public GameObject cursor;
    private bool cursorMove= false;
    private IEnumerator leftmove;
    private IEnumerator rightmove;
    private IEnumerator upmove;
    private IEnumerator downmove;
    public GameObject leftBound,rightBound;
    private bool left, right, up, down;
    public BoxCollider Hitbox;
    public GameObject diveButton;
    private void Awake()
    {
        fireTime = new WaitForSeconds(PawnAttributesSO.fireRate);
        downmove = MoveCursorDown();
        upmove = MoveCursorUp();
        rightmove = MoveCursorRight();
        leftmove = MoveCursorLeft();
    }

    public void StartShooting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PawnAttributesSO.canShoot = true;
            StartCoroutine(shooting());
            cursorMove = true;
        }
        if (context.canceled)
        {
            PawnAttributesSO.canShoot = false;
            StopCoroutine(shooting());
            cursorMove = false;
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
        if (context.performed && !up)
        {
            StartCoroutine(upmove);
        }

        if (context.canceled)
        {
            StopCoroutine(upmove);
            up = false;
        }
    }
    
    public void MoveCursorDown(InputAction.CallbackContext context)
    {
        if (context.performed && !down)
        {
            
            StartCoroutine(downmove);
        }

        if (context.canceled)
        {
            StopCoroutine(downmove);
            down = false;
        }
    }
    
    public void MoveCursorLeft(InputAction.CallbackContext context)
    {
        if (context.performed && !left)
        {
            StartCoroutine(leftmove);
        }

        if (context.canceled)
        {
            StopCoroutine(leftmove);
            left = false;
        }
    }
    
    public void MoveCursorRight(InputAction.CallbackContext context)
    {
        if (context.performed && !right)
        {
            StartCoroutine(rightmove);
        }

        if (context.canceled)
        {
            StopCoroutine(rightmove);
            right = false;
        }
    }
    private IEnumerator MoveCursorUp()
    {
        up = true;
        while (cursorMove)
        {
            if (cursor.transform.position.y !< 4.45)
            {
                cursor.transform.Translate(Vector3.up * (PawnAttributesSO.speed* 1.5f * Time.deltaTime));
                //Debug.Log("Up");
            }
            else
            {
                //Debug.Log("upperLimit");
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorDown()
    {
        down = true;
        while (cursorMove)
        {
            if (cursor.transform.position.y !> -5.1)
            {
                cursor.transform.Translate(Vector3.down * (PawnAttributesSO.speed * 1.5f * Time.deltaTime));
                //Debug.Log("Down");
            }
            else
            {
                //Debug.Log("bottomLimit");
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorLeft()
    {
        left = true;
        while (cursorMove)
        {
            if (cursor.transform.position.x > leftBound.transform.position.x)
            {
                cursor.transform.Translate(Vector3.left * (PawnAttributesSO.speed * 2f * Time.deltaTime));
                //Debug.Log("movingLeft");
            }
            else
            {
                //Debug.Log("leftLimit");
            }
            yield return waitFixed;
        }
    }
    private IEnumerator MoveCursorRight()
    {
        right = true;
        while (cursorMove)
        {
            if (cursor.transform.position.x < rightBound.transform.position.x)
            {
                cursor.transform.Translate(Vector3.right * (PawnAttributesSO.speed * 2f * Time.deltaTime));
                //Debug.Log("movingRight");
            }
            else
            {
                //Debug.Log("RightLimit");
            }
            yield return waitFixed;
        }
    }

    public void DiveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Hitbox.enabled = false;
            diveButton.SetActive(false);
            rb.transform.Translate(Vector3.right);
            StartCoroutine(ReEnabelHitbox());
        }
    }
    public void DiveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Hitbox.enabled = false;
            diveButton.SetActive(false);
            rb.transform.Translate(Vector3.left);
            StartCoroutine(ReEnabelHitbox());
        }
    }

    private IEnumerator ReEnabelHitbox()
    {
        yield return new WaitForSeconds(.5f);
        Hitbox.enabled = true;
        yield return new WaitForSeconds(2);
        diveButton.SetActive(true);
    }
}
