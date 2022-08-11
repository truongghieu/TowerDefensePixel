using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Healther : Army
{
    public ParticleSystem skillEffect;
    bool skilled = false;

    protected override void Start()
    {
        base.Start();
        skillEffect.Stop();
    }
    protected override void Update()
    {
        skill(null);
    }

    protected override void Animate()
    {
        transform.DOScale(new Vector3(1.1f,1.1f,0),0.2f).SetLoops(-1,LoopType.Yoyo);
    }
    protected override void skill(GameObject enemy)
    {
        if(skilled) return;
        skilled = true;
        GameManager.instance.Health += (this.Level + 1);
        skillEffect.Play();
        StartCoroutine(timing());
    }
    IEnumerator timing(){
        yield return new WaitForSeconds(attackSpeed);
        skilled = false;
    }
}
