using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField]
    private float distanceAParcourir = 2;
    [SerializeField]
    private float speed = 2;

    protected GameObject player;
    Vector3 TargetDeplacement;
    float distanceParcourue = 100;
    private Animator anim;
    EnemyDistAttack eda;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        eda = GetComponent<EnemyDistAttack>();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            GetComponentInParent<EnemySpawner>().OnEnemyDeath();
            anim.SetBool("IsDead", true);
            Destroy(this.gameObject, 0.35f);
            //game over -> replay ou return to menu ou quit
        }
        else
        {
            MoveAfterHit();
        }
    }


    //TODO : bouger la gestion du déplacement dans une classe EnemyDeplacement
    private void MoveAfterHit()
    {
        StartCoroutine(Touche());
    }

    private void Update()
    {

        if (!LevelManager.Instance.IsPaused)
        {
            if (distanceParcourue <= distanceAParcourir)
            {
                Vector3 deplacememnt = TargetDeplacement * speed * Time.deltaTime;
                transform.position += deplacememnt;
                distanceParcourue += deplacememnt.magnitude;
            }
            transform.rotation = new Quaternion();
        }
    }

    private IEnumerator Touche()
    {
        if (eda)
        {
            eda.CanMove = false;
            eda.CanShoot = false;
        }
        anim.SetBool("IsHurt", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsHurt", false);
        if (eda)
        {
            eda.CanMove = true;
        }
    }
}
