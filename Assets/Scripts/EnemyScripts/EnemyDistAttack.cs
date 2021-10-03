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
    [SerializeField]
    private Transform bulletContainer;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private float delaiEntreAttaque = 0.2f;
    [SerializeField]
    private float projectileSpeed = 60;

    private GameObject player;

    private float timerAttack;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timerAttack = ((float)Random.Range(0, 10) / 10) - 1;
        Debug.Log("temps avant 1ere attaque = " + timerAttack);
    }

    // Update is called once per frame
    void Update()
    {
        timerAttack += Time.deltaTime;
        if (!player)
        {
            return;
        }
        if (timerAttack >= delaiEntreAttaque)
        {
            float angletarget = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg;
            GameObject go = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation, bulletContainer);
            go.GetComponent<Rigidbody2D>().velocity = projectileSpeed * bulletSpawn.right;
            Destroy(go, 5);
            timerAttack = 0;
        }
    }
}
