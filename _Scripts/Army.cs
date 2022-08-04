using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Army : MonoBehaviour
{

    [Header("ARMY INFO")]

    public int damage = 1;
    public int armyHealth = 5;
    public int armyCost = 2; 
    [SerializeField]private float attackSpeed = 2f;


    [Header("Others")]
    public GameObject Bullet;
    private bool isAttack = false;
    private ParticleSystem bulletEffect;

    [Header("LEVEL UPGRADE")]
    protected SpriteRenderer ArmySpriteRender;
    public int Level = -1;
    public int[] CostToNextLevel;
    public Sprite[] SpritesNextLevel;
    public int[] DameNextLevel;
    public float[] AttackSpeedNextLevel;



    protected virtual void Start(){
        init();
        Animate();

    }

    protected virtual void Update()
    {

        Attack();
        
    }
    protected virtual void Attack(){
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(!isAttack){
            isAttack = true;
            if(enemy != null){
            transform.DOShakePosition(0.1f,0.2f);
            /// attack
            bulletEffect.Play();
            Bullet.transform.DOMove(enemy.transform.position,attackSpeed/3);
            StartCoroutine(atackTiming());
            }else{
                isAttack = false;
            }
        }    
    }
    protected virtual void skill(){

    }


    protected virtual void Animate(){
        transform.DOScaleY(0.97f,0.2f).SetLoops(-1,LoopType.Yoyo);
        transform.DOMoveY(transform.position.y - 0.05f,0.1f).SetLoops(-1,LoopType.Yoyo);
    }


    protected virtual void init(){
        bulletEffect = Bullet.GetComponent<ParticleSystem>();
        ArmySpriteRender = GetComponentInChildren<SpriteRenderer>();
        bulletEffect.Stop();
    }

    IEnumerator atackTiming(){
        yield return new WaitForSeconds(attackSpeed /3);
        bulletEffect.Stop();
        Bullet.transform.position = this.transform.position;
        yield return new WaitForSeconds(attackSpeed * 2 / 3 );
        isAttack = false;
    }
    public virtual void Upgrade(){
        if(GameManager.instance.Gold >= CostToNextLevel[Level + 1]){
        Level += 1;
        GameManager.instance.Gold -= CostToNextLevel[Level];
        ArmySpriteRender.sprite = SpritesNextLevel[Level];
        damage = DameNextLevel[Level];
        attackSpeed = AttackSpeedNextLevel[Level];
        }
    }
}
