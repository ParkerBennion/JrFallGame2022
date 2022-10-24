using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public SO_Vector3 endPosition;
    private Rigidbody rb;
    private WaitForSeconds half;
    private Vector3 positionNow;
    private Vector3 myPosition;
    public GameObject whereToHit;
    public float destroyTime;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        half = new WaitForSeconds(destroyTime);
    }
    private void Start()
    {
        StartCoroutine(destruct());
        positionNow = endPosition.position;
        myPosition = transform.position;
        //Debug.Log(positionNow);
        Instantiate(whereToHit, positionNow, transform.rotation);

    }
    private IEnumerator destruct()
    {
        yield return half;
        Destroy(gameObject);
    }
    void Update()
    {
        //rb.velocity = Vector.Lerp(transform.position, endPosition.position, transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime);
        rb.transform.position = Vector3.Lerp(transform.position, positionNow,  .001f);
    }
}
