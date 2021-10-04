using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int health = 10;

    protected bool isInvincible = false;

    public virtual void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
        }
    }
}
