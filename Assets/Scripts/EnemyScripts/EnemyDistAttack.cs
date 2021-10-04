using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gestion de l'attaque pour les ennemies distances
/// </summary>
public class EnemyDistAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private Transform bulletContainer;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private float delaiEntreAttaque = 0.2f;
    [SerializeField]
    private float projectileSpeed = 60;

    private GameObject player;

    private float timerAttack;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timerAttack = ((float)Random.Range(0, 10) / 10) - 1;
        Debug.Log("temps avant 1ere attaque = " + timerAttack);
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timerAttack += Time.deltaTime;
        if (!player)
        {
            return;
        }

        if (player != null)
        {
            if ((player.transform.position - transform.position).magnitude > 5)
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
        if (canShoot)
        {
            if (timerAttack >= delaiEntreAttaque)
            {
                float angletarget = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg;
                GameObject go = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation, bulletContainer);
                go.GetComponent<Rigidbody2D>().velocity = projectileSpeed * bulletSpawn.right;
                Destroy(go, 0.5f);
                timerAttack = 0;
            }
        }
    }
}
