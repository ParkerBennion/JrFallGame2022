using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PawnMovements
{
    private WaitForSeconds fireTime;

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
}
