using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPositions;
    private Vector3[] locations;
    
    public GameObject[] enemyPrefab;

    private WaitForSeconds TimerShort;
    private WaitForSeconds TimerMed;
    private WaitForSeconds TimerLong;
    private int switcher = 0;
    

    private void Awake()
    {
        TimerLong = new WaitForSeconds(5);
        TimerMed = new WaitForSeconds(2);
        TimerShort = new WaitForSeconds(1);
        
            locations = new Vector3[spawnPositions.Length];
    }

    public void StartSequence()
    {
        StartCoroutine(SpawnOneSequence());
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
         SwitchSpawnSequence(100);
     }


     private void SwitchSpawnSequence(int commandToRun)
     {
         switch (commandToRun)
         {
             case 100:
             {
                 for (int i = 0; i < locations.Length; i++)
                 {
                     enemyPrefab[0].transform.position = locations[i];
                     Instantiate(enemyPrefab[0]);
                 }
                 break;
             }
             case 0:
             {
                 Debug.Log("spawning initialized");
                 break;
             }
             case 1:
             {
                 Debug.Log("Spawn start");
                 enemyPrefab[0].transform.position = locations[0];
                 Instantiate(enemyPrefab[0]);
                 break;
             }
             case 2:
             {
                 enemyPrefab[1].transform.position = locations[1];
                 Instantiate(enemyPrefab[1]);
                 break;
             }
             case 3:
             {
                 break;
             }
             case 4:
             {
                 Debug.Log("resetting sequence");
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
             SwitchSpawnSequence(switcher);
             switcher += 1;
             yield return TimerLong;
         }


     }

}
