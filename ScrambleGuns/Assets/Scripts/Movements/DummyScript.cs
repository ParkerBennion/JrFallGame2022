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
    public string[] InCoverTags;
    private bool ammunition = true;
    public UnityEvent OnDeath;
    private int leftOrRight = 1;


    public bool canBeShot = true;

    void Start()
    {
        thisCollider = GetComponent<BoxCollider>();
        
        if (transform.position.x > 0)
        {
            leftOrRight = -1;
        }

        foreach (var command  in stats.codex)
        {
            SwitchSpawnSequence(command);
        }
    }
    
    public void SwitchSpawnSequence(int codeCommand)
    {
         
        switch (codeCommand)
        {
            case 1:
            {
                StartCoroutine(moveDummyRight());
                break;
            }
            case 2:
            {
                Debug.Log("2");
                ImmuneTillStop();
                break;
            }
            case 3:
            {
                Debug.Log("3");
                break;
            }
            default:
            {
                Debug.Log("default");
                break;
            }
        }
    }

    private void ImmuneTillStop()
    {
        canBeShot = false;
    }


    /*IEnumerator moveDummy()
    {
        while (leftRight)
        {
            transform.Translate(Vector3.left * (leftOrRight * (Time.deltaTime * 3)));
            yield return wffu;
        }
        while (!leftRight)
        {
            transform.Translate(Vector3.right * (leftOrRight * (Time.deltaTime * 3)));
            yield return wffu;
        }

        if (timer)
        {
            StartCoroutine(moveDummy());
        }
    }*/
    
    IEnumerator moveDummyLeft()
    {
        leftRight = true;
        while (leftRight)
        {
            transform.Translate(Vector3.left * (leftOrRight * (Time.deltaTime * 3)));
            yield return wffu;
        }
    }
    
    IEnumerator moveDummyRight()
    {
        leftRight = true;
        while (leftRight)
        {
            transform.Translate(Vector3.right * (leftOrRight * (Time.deltaTime * 3)));
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
            yield return new WaitForSeconds(stats.fireRate);
            Instantiate(Bullet, transform.position,transform.rotation);
            //yield return new WaitForSeconds(Random.Range(1.2f,2.7f));
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
            //Debug.Log("hit");
        }
        
        if (other.name.Contains(stats.stopper))
        {
            leftRight = false;
            StartCoroutine(StartShooting());
            canBeShot = true;
        }
        
        if (other.CompareTag("EdgeStopper"))
        {
            
            StartCoroutine(moveDummyLeft());
        }
        
        for (int i = 0; i < InCoverTags.Length; i++)
        {
            if (other.CompareTag(InCoverTags[i]))
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
        for (int i = 0; i < InCoverTags.Length; i++)
        {
            if (other.CompareTag(InCoverTags[i]))
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
