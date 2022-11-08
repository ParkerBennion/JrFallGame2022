using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayersBullet : MonoBehaviour

    {
    public SO_Vector3 endPosition;
    private WaitForSeconds Timer;
    
    private Vector3 positionNow;

    public SO_Vector3 myPosition;
    private Vector3 myPositionAtShoot;

    private float randX, randY;
    
    public float destroyTime;
    private float elapsTime;
    
    private void Awake()
    {
        Timer = new WaitForSeconds(destroyTime);
        positionNow = endPosition.position;
        randX = Random.Range(-.2f, .2f);
        randY = Random.Range(-.2f, .2f);

        positionNow.x += randX;
        positionNow.y += randY;

    }
    private void Start()
    {
        StartCoroutine(destruct());


        myPositionAtShoot = myPosition.position;
        //set the position to a set position in place of a moving position

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
        transform.position = Vector3.Lerp(myPositionAtShoot, positionNow, percentageComplete);
    }
}
