using System;
using UnityEngine;

public class EnemyMoveOne : MonoBehaviour
{
    private bool leftToRight;
    
    private void Awake()
    {
        if (transform.position.x >= 0)
        {
            leftToRight = false;
        }
        else
        {
            leftToRight = true;
        }
    }

    private void Update()
    {
        if (leftToRight)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 3));
        }
        transform.Translate(Vector3.right * (Time.deltaTime * 3));
    }
}
