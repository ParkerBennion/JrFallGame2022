using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public SO_Vector3 endPosition;
    private Rigidbody rb;
    private WaitForSeconds Timer;
    
    private Vector3 positionNow;

    private Vector3 myPosition;
    
    public GameObject whereToHit;//the player
    public SpriteRenderer playerRenderer;
    
    public float destroyTime;
    private float elapsTime;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Timer = new WaitForSeconds(destroyTime);
        positionNow = endPosition.position;
    }
    private void Start()
    {
        StartCoroutine(destruct());


        myPosition = transform.position;
        //set the position to a set position in place of a moving position


        Instantiate(whereToHit, positionNow, transform.rotation);
        //creates the bullets marker

    }
    private IEnumerator destruct()
    {
        yield return Timer;
        Destroy(gameObject);
    }
    void Update()
    {
        elapsTime += Time.deltaTime;
        float percentageComplete = elapsTime / destroyTime;
        //rb.velocity = Vector.Lerp(transform.position, endPosition.position, transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime);
        transform.position = Vector3.Lerp(myPosition, positionNow, percentageComplete);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRenderer.color = Color.red;
            Debug.Log("HitPlayer");
        }
    }
}
