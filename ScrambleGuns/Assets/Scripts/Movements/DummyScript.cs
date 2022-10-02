using System.Collections;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public bool timer = true;
    public bool leftRight = false;
    private WaitForFixedUpdate wffu;
    
    void Start()
    {
        StartCoroutine(moveDummy());
        StartCoroutine(Timer());
    }

    IEnumerator moveDummy()
    {
        while (leftRight)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 3));
            yield return wffu;
        }
        while (!leftRight)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * 3));
            yield return wffu;
        }

        if (timer)
        {
            StartCoroutine(moveDummy());
        }
    }
    
    IEnumerator Timer()
    {
        while (timer)
        {
            yield return new WaitForSeconds(4);
            leftRight = true;
            Debug.Log("true");
            yield return new WaitForSeconds(4);
            leftRight = false;
            Debug.Log("false");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
    }
    
}
