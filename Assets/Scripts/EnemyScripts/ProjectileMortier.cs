using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortier : MonoBehaviour
{
    [SerializeField]
    private int degat = 2;
    [SerializeField]
    private float tempsAvantExplosion = 1;
    [SerializeField]
    private float areaOfDamageRadius = 1;

    private PlayerHealth player;
    private Rigidbody2D rb;
    private Animator anim;

    private bool isAtTargetPos = false;
    private float timer = 0;

    private float yTarget;
    public float YTarget
    {
        get { return yTarget; }
        set { yTarget = value; }
    }
    private bool aDepasseYTarget = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!LevelManager.Instance.IsPaused)
        {
            if (!aDepasseYTarget && transform.position.y > yTarget)
            {
                aDepasseYTarget = true;
            }
            if (aDepasseYTarget && transform.position.y <= yTarget)
            {
                if (anim)
                {
                    anim.SetBool("IsTriggering", true);
                }
                rb.velocity = new Vector2();
                rb.gravityScale = 0;
                timer += Time.deltaTime;
                if (timer > tempsAvantExplosion)
                {
                    if (player)
                    {
                        if ((player.transform.position - transform.position).magnitude <= areaOfDamageRadius)
                        {
                            player.TakeDamage(degat);
                        }
                    }
                    if (anim)
                    {
                        anim.SetBool("IsExploding", true);
                    }
                    Destroy(this.gameObject, 0.35f);
                }
            }
        }
    }
}
