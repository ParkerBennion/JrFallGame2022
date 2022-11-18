using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPositions;
    private Vector3[] locations;
    
    public GameObject[] enemyPrefab;
    
    public WaitForSeconds TimerShort;
    public WaitForSeconds TimerMed;
    public WaitForSeconds TimerLong;
    private int switcher = 1;
    

    private void Awake()
    {
        TimerLong = new WaitForSeconds(5);
        TimerMed = new WaitForSeconds(2);
        TimerShort = new WaitForSeconds(1);
        
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

         //StartCoroutine(TestingAllSpawns());
         StartCoroutine(SpawnOneSequence());
     }
     
     
     public void SwitchSpawnSequence()
     {
         
         switch (switcher)
         {
             case 1:
             {
                 enemyPrefab[0].transform.position = locations[0];
                 Instantiate(enemyPrefab[0]);
                 enemyPrefab[1].transform.position = locations[1];
                 Instantiate(enemyPrefab[1]);
                 enemyPrefab[2].transform.position = locations[2];
                 Instantiate(enemyPrefab[2]);
                 enemyPrefab[0].transform.position = locations[3];
                 Instantiate(enemyPrefab[0]);
                 enemyPrefab[1].transform.position = locations[4];
                 Instantiate(enemyPrefab[1]);
                 enemyPrefab[2].transform.position = locations[5];
                 Instantiate(enemyPrefab[2]);
                 //Debug.Log("1");
                 break;
             }
             case 2:
             {
                 break;
             }
             default:
             {
                 //Debug.Log("break");
                 switcher = 0;
                 break;
             }
         }
     }
     

     IEnumerator TestingAllSpawns()
     {
         for (int i = 0; i < spawnPositions.Length; i++)
         {
             enemyPrefab[i].transform.position = locations[i];
             Instantiate(enemyPrefab[i]);
         }
      
         yield break;
     }
     /*IEnumerator SpawnOnlyFront()
     {
         while (true)
         {
             enemyPrefab[0].transform.position = locations[0];
             Instantiate(enemyPrefab[0]);
             yield return TimerShort;
         }
      
         yield break;
     }*/
     


     IEnumerator SpawnOneSequence()
     {
         bool SequenceGo = true;
         while (SequenceGo)
         {
             SwitchSpawnSequence();
             switcher += 1;
             yield return TimerLong;
         }


     }

}
