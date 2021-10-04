using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMortier : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float delaBtwTirs = 3;
    [SerializeField]
    private Transform bulletSpawner;
    [SerializeField]
    private float tempsAvantImpact = 2;


    private Transform bulletContainer;

    private GameObject player;

    private Vector3 target;
    private float timeSinceLastShoot = 0;
    private Vector3 basePos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer").transform;
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsPaused)
        {
            transform.position = basePos;
            transform.rotation = new Quaternion();
            timeSinceLastShoot += Time.deltaTime;
            if (timeSinceLastShoot > delaBtwTirs)
            {
                timeSinceLastShoot = 0;
                SetTarget();
                Shoot();
            }
        }
    }

    private void SetTarget()
    {
        if(player)
            target = player.transform.position - bulletSpawner.position;
    }
    private void Shoot()
    {
        GameObject go = Instantiate(projectilePrefab, bulletSpawner.position, new Quaternion(), bulletContainer);
        go.GetComponent<ProjectileMortier>().YTarget = player.transform.position.y;
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(target.x / tempsAvantImpact, (target.y / tempsAvantImpact) + 9.81f* tempsAvantImpact / 2);
    }
}
