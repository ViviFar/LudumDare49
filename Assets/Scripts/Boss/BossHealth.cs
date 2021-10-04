using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{
    protected override void Start()
    {
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            StartCoroutine(BossDeath());   
        }
    }

    private void Update()
    {

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.M))
        {
            health -= (maxHealth - 1);
        }
#endif  
    }

    private IEnumerator BossDeath()
    {
        //launch anim
        yield return new WaitForSeconds(1); //animation duration + leger délai
        LevelManager.Instance.ShowVictoryPanel();
    }
}
