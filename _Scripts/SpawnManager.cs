using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [Header("SETUP ENEMY SPAWN")]
    public GameObject[] Enemys;
    public Vector3 SpawnPoint;
    public Vector3 EndPoint;
    public float[] TimeToNextSpawn;
    public int[] NumberOfEnemyToSpawn;
    [Range(2f,10f)]
    public float[] TimeEachSpawn;



    void Start(){
        StartToSpawn();
    }




    void StartToSpawn(){
            StartCoroutine(Timing());

        
    }

    IEnumerator Timing(){
        for(int gameRound = 0 ; gameRound < Enemys.Length ; gameRound ++ ){
        yield return new WaitForSeconds(TimeToNextSpawn[gameRound]);
        for(int i= 0 ; i<  NumberOfEnemyToSpawn[gameRound];i++){
            SpawnOneUnit(gameRound);
            yield return new WaitForSeconds(TimeEachSpawn[gameRound]);
        }
    }
        
    }

    private void SpawnOneUnit(int index)
    {
        GameObject e = Instantiate(Enemys[index],SpawnPoint,Quaternion.identity);
        e.transform.parent = GameObject.Find("EnemyHold").transform;
    }
}
