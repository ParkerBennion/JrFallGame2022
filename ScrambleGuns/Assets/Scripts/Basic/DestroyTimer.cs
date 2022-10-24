using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float desTimer;
    private WaitForSeconds desTimerWait;
    void Start()
    {
        desTimerWait = new WaitForSeconds(desTimer);
        StartCoroutine(destroy());
    }

    private IEnumerator destroy()
    {
        yield return desTimerWait;
        Destroy(gameObject);
    }
}
