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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponentInParent<EnemySpawner>().OnEnemyDeath();
            Destroy(this.gameObject);
            //game over -> replay ou return to menu ou quit
        }
        MoveAfterHit();
    }


    //TODO : bouger la gestion du déplacement dans une classe EnemyDeplacement
    private void MoveAfterHit()
    {
        if (player != null)
        {
            distanceParcourue = 0;
            TargetDeplacement = player.transform.position - transform.position + new Vector3(Random.Range(-2,2), Random.Range(-2, 2), 0);
            TargetDeplacement *= -1;
            TargetDeplacement.Normalize();
        }
    }

    private void Update()
    {
        if (distanceParcourue <= distanceAParcourir) {
            Vector3 deplacememnt = TargetDeplacement * speed * Time.deltaTime;
            transform.position += deplacememnt;
            distanceParcourue += deplacememnt.magnitude;
        }
        transform.rotation = new Quaternion();
    }
}
