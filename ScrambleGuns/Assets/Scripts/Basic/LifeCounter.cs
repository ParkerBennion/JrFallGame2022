using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeCounter : MonoBehaviour
{
    public GameObject life1, life2;
    public int life;
    public UnityEvent noLife;
    private void Awake()
    {
        life = 2;
        life1.SetActive(true);
        life2.SetActive(true);
    }

    public void TakeLife()
    {
        life--;
        life1.SetActive(false);
        if (life<1)
        {
            life2.SetActive(false);
        }

        if (life<0)
        {
            noLife.Invoke();
        }
    }
}
