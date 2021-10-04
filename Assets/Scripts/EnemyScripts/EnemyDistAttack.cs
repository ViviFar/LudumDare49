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
    [SerializeField]
    private float enemySpeed = 11;

    private GameObject player;

    private float timerAttack = 0;
    private bool canShoot = true;
    private int movementMode = 0;  // 0 for going towards the player, 1 for random movement
    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    private bool canMove = true;
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }


    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        timerAttack = ((float)Random.Range(0, 10) / 10) - 1;
        Debug.Log("temps avant 1ere attaque = " + timerAttack);
        bulletContainer = LevelManager.Instance.BulletContainer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsPaused)
        {
            timerAttack += Time.deltaTime;
            if (!player)
            {
                return;
            }

            if (canMove)
            {
                if (player != null)
                {
                    if ((player.transform.position - transform.position).magnitude > 3)
                    {
                        canShoot = false;
                        Vector3 dir = new Vector3();
                        if (Random.Range(0, 1000)  > 950)
                        {
                            movementMode = -1*movementMode + 1;
                        }
                        if (movementMode == 0)
                        {
                            dir = (player.transform.position - transform.position);
                            dir.Normalize();
                        }
                        if (movementMode == 1)
                        {   
                            dir = (player.transform.position - transform.position);
                            dir.x = dir.x * Random.Range(0, 100) / 100;
                            dir.y = dir.y * Random.Range(0, 100) / 100;
                            dir.Normalize();
                        }
                        transform.position += dir * enemySpeed * Time.deltaTime;
                    }
                    else
                    {
                        canShoot = true;
                    }
                }
            }
            if (canShoot)
            {
                if (timerAttack >= delaiEntreAttaque)
                {
                    StartCoroutine(Shoot());

                }
            }
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        canMove = false;
        anim.SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.83f);
        float angletarget = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg;
        GameObject go = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation, bulletContainer);
        go.GetComponent<Rigidbody2D>().velocity = projectileSpeed * bulletSpawn.right;
        Destroy(go, 1.0f);
        timerAttack = 0;
        anim.SetBool("IsShooting", false);
        canMove = true;
    }
}
