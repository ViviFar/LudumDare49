using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private PlayerStatus status;
    private void Start()
    {
        status = GetComponent<PlayerStatus>();
    }

    public override void TakeDamage(int damage)
    {
        if(status.CurrentPlayerState == PlayerState.Solide)
        {
            base.TakeDamage(1);
        }
        else{
            base.TakeDamage(damage);
        }
    }

    public void LaunchInvincibilite(float duration)
    {
        StartCoroutine(Invincibilite(duration));
    }

    private IEnumerator Invincibilite(float duration)
    {
        isInvincible = true;
        Debug.Log("start invincibilite");
        yield return new WaitForSeconds(duration);
        Debug.Log("end invincibilite");
        isInvincible = false;
    }
}
