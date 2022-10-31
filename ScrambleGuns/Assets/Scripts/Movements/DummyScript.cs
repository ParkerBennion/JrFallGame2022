using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class DummyScript : MonoBehaviour
{
    public bool timer = true;
    public bool leftRight = true;
    private WaitForFixedUpdate wffu;
    public GameObject Bullet;
    public EnemyStat_SO stats;
    public BoxCollider thisCollider;
    public string[] theseTags;
    public string stopperName;
    private bool ammunition = true;
    public UnityEvent OnDeath;


    public bool canBeShot = true;

    void Start()
    {
        //StartCoroutine(moveDummy());
        //StartCoroutine(Timer());
        StartCoroutine(moveDummyRight());
        thisCollider = GetComponent<BoxCollider>();
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
    
    IEnumerator moveDummyLeft()
    {
        leftRight = true;
        while (leftRight)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 3));
            yield return wffu;
        }
    }
    
    IEnumerator moveDummyRight()
    {
        leftRight = true;
        while (leftRight)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * 3));
            yield return wffu;
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
        
        if (other.CompareTag("PlayerBullet") && canBeShot)
        {
            //in unity function to call appropriate procedural death effects (respawning the stoppers)
            OnDeath.Invoke();
            //callYourHit.lastInt = gameObject.transform.GetHashCode();
            StartCoroutine(DeathSequence());
            //Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
        
        if (other.name.Contains(stopperName))
        {
            leftRight = false;
            StartCoroutine(StartShooting());
        }
        
        if (other.CompareTag("EdgeStopper"))
        {
            
            StartCoroutine(moveDummyLeft());
        }
        
        for (int i = 0; i < theseTags.Length; i++)
        {
            if (other.CompareTag(theseTags[i]))
            {
                canBeShot = false;
                ammunition = false;
                return;
            }
        }
        
        //destroy on bullet
        
    }
    
    
    //on exit compares the tags with list and sets bools.
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

    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
