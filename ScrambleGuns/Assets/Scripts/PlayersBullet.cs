using System;
using System.Collections;
using UnityEngine;

public class PlayersBullet : MonoBehaviour
{
    public SO_Vector3 startPosition;
    public SO_Vector3 endPosition;

    private Rigidbody2D rb;

    private void Awake()
    {
        transform.position = startPosition.position;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(endPosition.position);
        Debug.Log(startPosition.position);
    }

    private void Start()
    {
        StartCoroutine(destruct());
    }


    void Update()
    {
        //rb.velocity = Vector.Lerp(transform.position, endPosition.position, transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime);
        rb.transform.position = Vector3.Lerp(transform.position, endPosition.position,  .1f);
    }

    private IEnumerator destruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
