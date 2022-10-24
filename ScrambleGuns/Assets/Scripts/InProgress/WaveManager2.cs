using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager2 : MonoBehaviour
{
    public GameObject[] spawns;
    //spawn Positions
    public GameObject[] fabs;
    //EnemyPrefabs
    private Vector3[] locations;
    //
    private WaitForSeconds TimerShort;
    private WaitForSeconds TimerMed;
    private WaitForSeconds TimerLong;

    private IEnumerator sequence;
    
    private void Awake()
    {
        TimerLong = new WaitForSeconds(3);
        TimerMed = new WaitForSeconds(2);
        TimerShort = new WaitForSeconds(1);
        
        locations = new Vector3[spawns.Length];
    }
    //assigns wfs and sets array size.
    private void Start()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            locations[i] = spawns[i].transform.position;
            //Debug.Log(locations[i]);
        }
    }
    
    
    
    // assigns spawn locatoins to vector3 to be used later

}