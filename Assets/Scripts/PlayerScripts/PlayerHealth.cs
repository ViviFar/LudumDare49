using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    private bool isInvincible = false;
    
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            Debug.Log("take " + damage + " damages, health remaining: " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
                //game over -> replay ou return to menu ou quit
            }
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
