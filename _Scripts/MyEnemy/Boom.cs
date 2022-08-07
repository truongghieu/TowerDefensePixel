using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Enemy
{
    [SerializeField] private ParticleSystem SkillEffect;
    [SerializeField] private float SkillTime;
    [SerializeField] private LayerMask ArmyLayer;
    private bool Skilling;

    public override void Update()
    {
        base.Update();
        skill();

    }
    protected override void skill()
    {
        if(!Skilling){
            Skilling = true;
            Collider2D[] cols =  Physics2D.OverlapCircleAll(transform.position,3,ArmyLayer);
            foreach(var col in cols){
                if(col.gameObject.tag == "Army"){
                    SkillEffect.Play();
                    col.gameObject.GetComponent<Army>().armyHealth -= this.enemyDame / 10;
                }
            }
        }

    }

    IEnumerator skillTime(){
        yield return new WaitForSeconds(SkillTime);
        Skilling = false;
    }
}
