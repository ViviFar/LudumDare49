using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int health = 10;

    protected bool isInvincible = false;

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            Debug.Log(gameObject.name + " take " + damage + " damages, health remaining: " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
                //game over -> replay ou return to menu ou quit
            }
        }
    }
}
