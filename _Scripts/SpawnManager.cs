using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [Header("SETUP ENEMY SPAWN")]
    public GameObject[] enemys;
    public Vector3 SpawnPoint;
    public int gameRound = 0;
    public float[] TimeToNextSpawn;
    public int[] NumberOfEnemyToSpawn;
    [Range(1f,2f)]
    public float[] TimeEachSpawn;



    void Start(){
        StartToSpawn();
    }




    void StartToSpawn(){
        for(int i = 0 ; i < enemys.Length ; i ++ ){
            StartCoroutine(Timing());
        }
    }

    IEnumerator Timing(){
        yield return new WaitForSeconds(TimeToNextSpawn[gameRound]);
        for(int i= 0 ; i<  NumberOfEnemyToSpawn[gameRound];i++){
            SpawnOneUnit();
            yield return new WaitForSeconds(TimeEachSpawn[gameRound]);
        }
        gameRound += 1;
    }

    private void SpawnOneUnit()
    {
        Instantiate(enemys[gameRound],SpawnPoint,Quaternion.identity);
    }
}
