using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField] public Vector3 endPoint = new Vector3(5,0.5f,0);
    public float timeGotoEndPoint = 5f;

    public virtual void Start(){
        gotoEndPoint();

    }
    public virtual void Update()
    {
    }
    protected virtual void gotoEndPoint(){
        transform.DOMove(endPoint , timeGotoEndPoint );

    }
    protected virtual void skill(){

    }
}
