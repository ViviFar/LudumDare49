using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField]
    private GameObject smokeBulletPrefab;
    [SerializeField]
    private GameObject waterBulletPrefab;

    [SerializeField]
    private float waterDelayBtwShoots = 2f;
    [SerializeField]
    private float smokeDelayBtwShoots = 0.5f;
    [SerializeField]
    private float smokeBulletSpeed = 5;

    [SerializeField]
    private Transform bulletContainer;
    [SerializeField]
    private Transform bulletSpawner;

    private float timerEntreShoots = 0;
    private Camera cam;

    //pour choisir le type d'attaque que le joueur pourra utiliser
    private PlayerStatus status;
    
    private void Start()
    {
        status = GetComponentInParent<PlayerStatus>();
        cam = Camera.main;
    }

    private void Update()
    {
        timerEntreShoots += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(status.CurrentPlayerState == PlayerState.Gazeux && timerEntreShoots > smokeDelayBtwShoots)
            {
                GameObject go = Instantiate(smokeBulletPrefab, bulletSpawner.position, bulletSpawner.rotation, bulletContainer);
                go.GetComponent<Rigidbody2D>().velocity = bulletSpawner.right * smokeBulletSpeed;
                Destroy(go, 5);
            }
            else if(status.CurrentPlayerState == PlayerState.Liquide && timerEntreShoots > waterDelayBtwShoots)
            {
                GameObject go = Instantiate(waterBulletPrefab, bulletSpawner.position, bulletSpawner.rotation, bulletContainer);
                Destroy(go, 0.25f);
            }
        }
    }
}
