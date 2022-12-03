using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPositions;
    private Vector3[] locations;
    
    public GameObject[] enemyFrontPrefabs;
    public GameObject[] enemyBackPrefabs;

    private int difficulty;
    private int quantity;
    private int iteration;

    private WaitForSeconds TimerShort;
    private WaitForSeconds TimerMed;
    private WaitForSeconds TimerLong;
    
    private int switcher = 0;
    

    private void Awake()
    {
        TimerLong = new WaitForSeconds(5);
        TimerMed = new WaitForSeconds(2);
        TimerShort = new WaitForSeconds(.5f);
        
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

         difficulty = 0;
         quantity = 1;
         iteration = 0;
         StartCoroutine(StartCountdown());
     }
     public void StartSequence()
     {
         StartCoroutine(StartCountdown());
     }
     
     
     
     private IEnumerator StartCountdown()
     {
         yield return TimerMed;
         StartCoroutine(SpawnOneSequence());
     }
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

     

     private void SwitchSpawnSequence(int commandToRun)
     {
         switch (commandToRun)
         {
             case 0:
             {
                 StartCoroutine(SpawnIntervalFront(quantity));
                 break;
             }
             case 1:
             {
                 StartCoroutine(SpawnIntervalBack(quantity));
                 break;
             }
             case 2:
             {
                 StartCoroutine(SpawnIntervalFront(quantity));
                 StartCoroutine(SpawnIntervalBack(quantity));
                 Debug.Log(difficulty);
                 Debug.Log(quantity);
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

     IEnumerator SpawnIntervalFront(int times)
     {
         for (int i = 0; i < times + iteration; i++)
         {
             GameObject tempEnemy = enemyFrontPrefabs[Random.Range(0, difficulty+1)]; 
             tempEnemy.transform.position = locations[Random.Range(0,2)];
             Instantiate(tempEnemy);
             yield return TimerShort;
         }
         quantity++;
         
         if (quantity > 3)
         {
             quantity = 1;
             iteration++;
             difficulty++;
             
             if (difficulty > enemyFrontPrefabs.Length)
             {
                 difficulty = enemyFrontPrefabs.Length;
             }
         }
     }
     IEnumerator SpawnIntervalBack(int times)
     {
         for (int i = 0; i < times + iteration; i++)
         {
             GameObject tempEnemy = enemyBackPrefabs[Random.Range(0, difficulty+1)]; 
             tempEnemy.transform.position = locations[Random.Range(2,4)];
             Instantiate(tempEnemy);
             yield return TimerShort;
         }
     }

     

}
