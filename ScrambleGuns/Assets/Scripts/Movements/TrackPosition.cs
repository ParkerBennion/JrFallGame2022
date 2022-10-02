using System.Collections;
using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    public SO_Vector3 currentPosition;
    private WaitForFixedUpdate wffu;
    public bool onUpdate;

    private void Awake()
    {
        currentPosition.position = transform.position;
    }

    private void Start()
    {
        if (onUpdate)
        {
            StartCoroutine(TrackLive());
        }
    }

    private IEnumerator TrackLive()
    {
        while (onUpdate)
        {
            currentPosition.position = transform.position;
            yield return wffu;
            //Debug.Log("tracking");
        }
        
    }

}
