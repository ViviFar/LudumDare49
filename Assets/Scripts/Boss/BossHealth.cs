using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            StartCoroutine(BossDeath());   
        }
    }

    private IEnumerator BossDeath()
    {
        //launch anim
        yield return new WaitForSeconds(1); //animation duration + leger délai
        LevelManager.Instance.ShowVictoryPanel();
    }
}
