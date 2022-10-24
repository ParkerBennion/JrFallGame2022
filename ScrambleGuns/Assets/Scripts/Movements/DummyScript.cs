using System;
using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class DummyScript : MonoBehaviour
{
    public bool timer = true;
    public bool leftRight = false;
    private WaitForFixedUpdate wffu;
    public GameObject Bullet;
    public EnemyStat_SO stats;
    public BoxCollider thisCollider;
    public string[] theseTags;
    private bool ammunition = true;


    public bool canBeShot = true;

    void Start()
    {
        StartCoroutine(moveDummy());
        StartCoroutine(Timer());
        thisCollider = GetComponent<BoxCollider>();
        StartCoroutine(StartShooting());
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
        }//////////////////////////////////////////////////////////////
    }

    IEnumerator StartShooting()
    {
        
        while (ammunition)
        {
            Instantiate(Bullet, transform.position,transform.rotation);
            //yield return new WaitForSeconds(Random.Range(1.2f,2.7f));
            yield return new WaitForSeconds(2);
        }///////////////////////////////////////////////////////
    }
    
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < theseTags.Length; i++)
        {
            if (other.CompareTag(theseTags[i]))
            {
                canBeShot = false;
                ammunition = false;
                return;
            }
        }
        
        if (other.CompareTag("PlayerBullet") && canBeShot)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < theseTags.Length; i++)
        {
            if (other.CompareTag(theseTags[i]))
            {
                ammunition = true;
                canBeShot = true;
                return;
            }
        }
    }
}
