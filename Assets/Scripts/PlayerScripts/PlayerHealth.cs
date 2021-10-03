using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
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
