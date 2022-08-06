using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{
    private bool _isOccupied= false;
    private GameObject BuildingUI,UpgradeUI;
    
    private GameObject myArmy;

    /// Army 
    public GameObject[] Armys;

    [Header("LOCAL UI")]
    [SerializeField] private TextMeshProUGUI[]  CostText;
    [SerializeField] private TextMeshProUGUI UpgradeCostText;

    void Start(){
        BuildingUI = transform.parent.Find("Canvas").transform.GetChild(0).gameObject;
        UpgradeUI = transform.parent.Find("Canvas").transform.GetChild(1).gameObject;
        UpdateCostText();

    }



    void UpdateCostText(){
        for(int i = 0; i < Armys.Length ; i++){
            CostText[i].text = Armys[i].GetComponent<Army>().armyCost.ToString() + "$";
        }
    }



    void OnMouseDown(){
        if(!GameManager.instance.isUI){
        Time.timeScale = 0; 
        GameManager.instance.isUI = true;
        if(_isOccupied == false){
            BuildingUI.SetActive(true);
        }else{
            // update text
            int level = myArmy.GetComponent<Army>().Level;
            if(myArmy.GetComponent<Army>().CostToNextLevel[level] == 999999){
                UpgradeCostText.text = "MAX";
            }else{
            UpgradeCostText.text = myArmy.GetComponent<Army>().CostToNextLevel[level].ToString() + "$";
            }
            ///
            UpgradeUI.SetActive(true);
        }
        }
    }
    public void cancelUI(){
        Time.timeScale = 1; 
        GameManager.instance.isUI = false;
        if(_isOccupied == false){
            BuildingUI.SetActive(false);
        }else{
            UpgradeUI.SetActive(false);
        }
    }

    public void spawnArmy(int index){
        GameManager.instance.isUI = false;
        if(Armys[index].GetComponent<Army>().armyCost <= GameManager.instance.Gold ){
        cancelUI();
        _isOccupied = true;
        this.myArmy = Instantiate(Armys[index],transform.position,Quaternion.identity);
        myArmy.transform.parent = GameObject.Find("ArmyHold").transform;
        GameManager.instance.Gold -= Armys[index].GetComponent<Army>().armyCost;
        }
    }

    public void removeArmy(){
        GameManager.instance.isUI = false;
        myArmy.transform.DOKill();
        Destroy(this.myArmy);
        cancelUI();
        _isOccupied = false;

        
    }
    public void UpgradeArmy(){
        GameManager.instance.isUI = false;
        this.myArmy.GetComponent<Army>().Upgrade();
        cancelUI();
    }
    
}
