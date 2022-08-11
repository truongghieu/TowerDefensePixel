using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isUI = false;

    [Header("PLAYER")]
    public int Gold = 20;
    public int Health = 10;

    void Awake(){
        if(instance != null ){
            Destroy(this);
        }else{
            instance = this;
        }
    }
    


}
