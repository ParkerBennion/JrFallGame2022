using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StopperScript : MonoBehaviour
{
    public SO_IntList hashStorrer;
    public int HashCode;
    public int ComparedCode;
    private Collider thisCollider;
    public string resetOnThisNameOnly;
    private SpriteRenderer thisRenderer;
    

    private void Awake()
    {
        thisCollider = GetComponent<Collider>();
        thisRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //detects the collision and stores the value of the object that hit it.
        if (other.gameObject.CompareTag("Enemy") /*&& other.gameObject.name.Contains(resetOnThisNameOnly)*/)
        {
            HashCode = other.gameObject.transform.GetHashCode();
            //Debug.Log(HashCode);
            //hashStorrer.AddInt(other.gameObject.transform.GetHashCode());
            thisCollider.enabled = false;
            thisRenderer.enabled = false;
            Debug.Log("deactivated");

            //gameObject.SetActive(false);
        }
    }

    //compared the hash that this individual object has with the one stored in the SO. if they are the same this reactivates.
    public void activate(SO_IntList hash)
    {
        if (HashCode == hash.lastInt)
        {
            Debug.Log("activated");
            thisCollider.enabled = true;
            thisRenderer.enabled = true;
        }
    }
}
