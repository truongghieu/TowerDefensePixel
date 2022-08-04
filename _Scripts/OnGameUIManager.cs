using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameUIManager : MonoBehaviour
{
    public static OnGameUIManager instance;
    public GameObject BuildUI;


    void Awake(){
        instance = this;
    }
    public void Building(){
        BuildUI.SetActive(true);
    }

}
