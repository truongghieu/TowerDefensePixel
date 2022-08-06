using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ENEMY INFO")]

    public int enemyGold = 2;
    public int enemyHealth = 2; 
    public int enemyDame = 1;
 
    [SerializeField] public Vector3 endPoint = new Vector3(3.5f,0.5f,0);
    public float speed = .2f;
    [Header("OTHES")]
    [SerializeField] GameObject Blood;

    public virtual void Start(){
        Animate();
        init();
    }
    public virtual void Update()
    {
        gotoEndPoint();
        updateStatus();
    }


    protected virtual void gotoEndPoint(){
        if(transform.position.x > endPoint.x) return;
        transform.position += new Vector3(speed * Time.deltaTime ,0,0);
    }

    protected virtual void skill(){

    }

    protected virtual void init(){
    }

    protected virtual void updateStatus(){
        if(transform.position.x > endPoint.x){
            GameManager.instance.Health -= this.enemyDame;
            transform.DOKill();
            Destroy(gameObject);
        }
        if(enemyHealth <= 0 ){
            transform.DOKill();
            GameObject blood = Instantiate(Blood,transform.position,Quaternion.identity);
            Destroy(blood,1f);   
            transform.DOKill();        
            Destroy(gameObject);
            GameManager.instance.Gold += this.enemyGold;
        }
    }


    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Bullet")){
            takeDameAnimate();
            enemyHealth -= other.GetComponentInParent<Army>().damage;
        }
    }
    /// Animation 
    protected virtual void Animate(){
        transform.DOScaleY(0.95f,0.1f).SetLoops(-1,LoopType.Yoyo);
        transform.DOMoveY(transform.position.y + 0.02f,0.2f).SetLoops(-1,LoopType.Restart );
    }
    protected virtual void takeDameAnimate(){
        transform.DOScale(new Vector3(1.1f,1.1f,1),0.1f);
    }
    

}
