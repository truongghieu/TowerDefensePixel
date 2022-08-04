using DG.Tweening;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    [SerializeField] GameObject Land;
    void Start()
    {
        SpawnLand();
    }
    void SpawnLand(){
        for(int x = -3 ; x  <2 ; x++ ){
            for(int y = -2 ; y < 4 ; y++){
                if(y != 0 && y != 1 ){
                GameObject myLand = Instantiate(Land,Vector2.zero,Quaternion.identity);
                myLand.transform.DOMove(new Vector3(x,y,0),1);
                }
            }
        }
    }
}
