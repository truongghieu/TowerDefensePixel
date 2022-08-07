using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    [Header("SETUP ENEMY SPAWN")]
    public GameObject[] Enemys;
    public Vector3 SpawnPoint;
    public Vector3 EndPoint;

    [Range(2f,10f)]
    public float TimeEachSpawn;
    [Range(2f,10f)]
    public float timeNextSpawn;
    private int numberOfEnemy;
    private int round;
    

    private bool spawning;

    void Start(){
        spawning = true;
        StartCoroutine(TimeToNextSpawn());
    }



    void Update(){
        numberOfEnemy = Mathf.RoundToInt(Mathf.Pow( Time.time - 5 , 0.3f));
        round = Mathf.RoundToInt((Time.time / 60) *  0.6f);
    }


   
   
    void Spawn(){
       StartCoroutine(SpawnEachUnit());
    }
    IEnumerator TimeToNextSpawn(){
            yield return new WaitForSeconds(timeNextSpawn);
            spawning = false;
            StartCoroutine(SpawnEachUnit());
        
    }


    IEnumerator SpawnEachUnit(){
        if(!spawning){
            spawning = true;
            for(int i = 0 ; i < numberOfEnemy ; i ++ ){
                
            Instantiate(Enemys[Mathf.Min(Random.Range(round,round+2),Enemys.Length)],SpawnPoint,Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(TimeEachSpawn-1.5f,timeNextSpawn + 1f));
            }
            }
            StartCoroutine(TimeToNextSpawn());
    }
    
}
