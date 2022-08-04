using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool _isOccupied= false;
    private GameObject BuildingUI,UpgradeUI;
    
    private GameObject myArmy;

    /// Army 
    public GameObject[] Armys;


    void Start(){
        BuildingUI = transform.parent.Find("Canvas").transform.GetChild(0).gameObject;
        UpgradeUI = transform.parent.Find("Canvas").transform.GetChild(1).gameObject;
    }
    void OnMouseDown(){
        Time.timeScale = 0; 
        if(_isOccupied == false){
            BuildingUI.SetActive(true);
        }else{
            UpgradeUI.SetActive(true);
        }
    }
    public void cancelUI(){
        Time.timeScale = 1; 
        if(_isOccupied == false){
            BuildingUI.SetActive(false);
        }else{
            UpgradeUI.SetActive(false);
        }
    }

    public void spawnArmy(int index){
        cancelUI();
        _isOccupied = true;
        this.myArmy = Instantiate(Armys[index],transform.position,Quaternion.identity);
        myArmy.transform.parent = GameObject.Find("EnemyHold").transform;
    }

    public void removeArmy(){
        _isOccupied = false;
        Destroy(this.myArmy);
    }
    public void UpgradeArmy(){
        this.myArmy.GetComponent<Army>().Upgrade();
    }
    
}
