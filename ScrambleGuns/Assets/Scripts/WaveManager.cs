using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPositions;
    private Vector3[] locations;
    public GameObject enemyPrefab;
    

    private void Awake()
    {
        locations = new Vector3[spawnPositions.Length];
    }

    //grabs vecor 3 cordnats for all object positions
     private void Start()
     {
         for (int i = 0; i < spawnPositions.Length; i++)
         {
             locations[i] = spawnPositions[i].transform.position;
             //Debug.Log(locations[i]);
         }

         StartCoroutine(TestingAllSpawns());
     }

     IEnumerator TestingAllSpawns()
     {
         for (int i = 0; i < spawnPositions.Length; i++)
         {
             enemyPrefab.transform.position = locations[i];
             Instantiate(enemyPrefab);
             
         }
      
         yield break;
     }
}
