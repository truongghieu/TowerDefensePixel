using DG.Tweening;
using UnityEngine;

public class Ice : Army
{
    [Header("SKILL")]
    public Color skillColor;
    private float slowDecrease;
    bool skilled = false;
    private GameObject currentTargetEnemy;

    protected override void Update()
    {
        if(currentTargetEnemy == null ) skilled = false;
        base.Update();

    }
    protected override void skill(GameObject enemy)
    {
        if(!skilled && currentTargetEnemy != null){
        slowDecrease = (float)(Level + 1) / 10;
        float sp = currentTargetEnemy.GetComponent<Enemy>().speed;
        currentTargetEnemy.GetComponent<Enemy>().speed = Mathf.Max(0,sp - slowDecrease);
        currentTargetEnemy.GetComponent<SpriteRenderer>().color = skillColor;
        skilled = true;
        }
        
    }

    protected override void Attack()
    {        
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(!isAttack){
            isAttack = true;
            if(enemy != null){
                currentTargetEnemy = enemy;
                skill(currentTargetEnemy);
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
}
