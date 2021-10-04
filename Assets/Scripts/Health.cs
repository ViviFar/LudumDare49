using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int health = 10;
    public int CurrentHealth
    {
        get { return health; }
    }

    protected int maxHealth;
    public int MaxHealth
    {
        get { return maxHealth; }
    }

    protected virtual void Start()
    {
        maxHealth = health;
    }

    protected bool isInvincible = false;

    public virtual void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
        }
    }
}
