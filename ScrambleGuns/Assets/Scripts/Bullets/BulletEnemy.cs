using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletEnemy : MonoBehaviour
{
    public SO_Vector3 endPosition;
    private Rigidbody rb;
    private WaitForSeconds Timer;
    
    private Vector3 positionNow;

    private Vector3 myPosition;

    public GameObject whereToHit;//the player
    public SpriteRenderer playerRenderer;

    private float randX, randY;
    
    public float destroyTime;
    private float elapsTime;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Timer = new WaitForSeconds(destroyTime);
        positionNow = endPosition.position;
        randX = Random.Range(-.5f, .5f);
        randY = Random.Range(-.7f, .7f);

        positionNow.x += randX;
        positionNow.y += randY;

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
}
