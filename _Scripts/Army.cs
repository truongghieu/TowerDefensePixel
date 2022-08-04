using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Army : MonoBehaviour
{

    [SerializeField]private float attackSpeed = 2f;
    private bool isAttack = false;

    protected virtual void Start(){
        Animate();

    }

    protected virtual void Update()
    {
        Attack();
        
    }
    protected virtual void Attack(){
        if(isAttack) return;
        transform.DOShakePosition(0.1f,0.2f);
        isAttack = true;
        /// attack
        print("atack the enemy");
        // Time countdown to next attack
        StartCoroutine(atackTiming());
    }
    protected virtual void skill(){

    }


    protected virtual void Animate(){
        transform.DOScaleY(0.97f,0.2f).SetLoops(-1,LoopType.Yoyo);
        transform.DOMoveY(transform.position.y - 0.05f,0.1f).SetLoops(-1,LoopType.Yoyo);
    }

    IEnumerator atackTiming(){
        yield return new WaitForSeconds(attackSpeed);
        isAttack = false;
    }
    public virtual void Upgrade(){

    }
}
