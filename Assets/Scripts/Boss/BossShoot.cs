using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField]
    private Transform[] shootingPositions;
    [SerializeField]
    private BossHealth bossHealth;
    [SerializeField]
    private float delaiEntreAttaques = .05f;
    [SerializeField]
    private float dureeAttaque = 5;
    [SerializeField]
    private float bulletSpeed = 15;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float epsilon = 0.1f;
    //le nombre max de tir lors d'une attaque. sera multiplié par 2 en phase 2;
    [SerializeField]
    private int nbTirParAttaque = 20;
    [SerializeField]
    private GameObject missilePrefab;
    [SerializeField]
    private Transform rotator;

    private Transform bulletContainer;

    private bool useCardinals = true;
    private float timeSinceLastShoot = 0;
    private int currentShootingPosUsed = 0;
    //le nombre de tirs actuellement fait par le boss lors de l'attaque courante
    private int nbShootFaitPdtAttaque = 0;

    List<Vector3> positionsPossible;
    private Vector3 centralPos;
    public Vector3 CentralPos {
        get { return centralPos; }
        set {
            centralPos = value;
            positionsPossible = new List<Vector3>();
            positionsPossible.Add(centralPos + new Vector3(3,3,0));
            positionsPossible.Add(centralPos + new Vector3(3,-3,0));
            positionsPossible.Add(centralPos);
            positionsPossible.Add(centralPos + new Vector3(-3,3,0));
            positionsPossible.Add(centralPos + new Vector3(-3,-3,0));

        }
    }
    int currentTargetPos = 0;

    private bool actif = false;
    Quaternion rotFixed;
    bool isShootingInPhase1 = false;

    private void Start()
    {
        bulletContainer = LevelManager.Instance.BulletContainer;
        LevelManager.Instance.Boss = this;
        rotFixed = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotFixed;
        if (actif)
        {
            //bugs avec la phase 2, à revoir dans une future update

            //if (bossHealth.CurrentHealth >= bossHealth.MaxHealth / 2 ||isShootingInPhase1)
            //{
                DoPattern1(Time.deltaTime);
            //}
            //else
            //{
            //    speed *= 1.5f;
            //    DoPattern2(Time.deltaTime);
            //}
        }
    }

    private void DoPattern1(float deltaTime)
    {
        if ((transform.position - positionsPossible[currentTargetPos]).magnitude>epsilon)
        {
            transform.position -= (transform.position - positionsPossible[currentTargetPos]).normalized * speed * deltaTime;
        }
        else
        {
            if (nbShootFaitPdtAttaque <= nbTirParAttaque) {
                isShootingInPhase1 = true;
                timeSinceLastShoot += deltaTime;
                if (timeSinceLastShoot > delaiEntreAttaques)
                {
                    GameObject go1 = Instantiate(missilePrefab, shootingPositions[currentShootingPosUsed].position, shootingPositions[currentShootingPosUsed].rotation, bulletContainer);
                    GameObject go2 = Instantiate(missilePrefab, shootingPositions[currentShootingPosUsed + 2].position, shootingPositions[currentShootingPosUsed + 2].rotation, bulletContainer);
                    GameObject go3 = Instantiate(missilePrefab, shootingPositions[currentShootingPosUsed + 4].position, shootingPositions[currentShootingPosUsed + 4].rotation, bulletContainer);
                    GameObject go4 = Instantiate(missilePrefab, shootingPositions[currentShootingPosUsed + 6].position, shootingPositions[currentShootingPosUsed + 6].rotation, bulletContainer);
                    go1.GetComponent<Rigidbody2D>().velocity = shootingPositions[currentShootingPosUsed].right * bulletSpeed;
                    go2.GetComponent<Rigidbody2D>().velocity = shootingPositions[currentShootingPosUsed+2].right * bulletSpeed;
                    go3.GetComponent<Rigidbody2D>().velocity = shootingPositions[currentShootingPosUsed+4].right * bulletSpeed;
                    go4.GetComponent<Rigidbody2D>().velocity = shootingPositions[currentShootingPosUsed+6].right * bulletSpeed;
                    nbShootFaitPdtAttaque++;
                    timeSinceLastShoot = 0;
                    rotator.eulerAngles = new Vector3(rotator.eulerAngles.x, rotator.eulerAngles.y, rotator.eulerAngles.z + 5);
                }
            }
            else
            {
                isShootingInPhase1 = false;
                //on change les positions d'attaque utilisées et on se déplace à la prochaine position.
                nbShootFaitPdtAttaque = 0;
                timeSinceLastShoot = 0;
                currentShootingPosUsed++;
                currentShootingPosUsed %= 2;
                currentTargetPos++;
                currentTargetPos %= positionsPossible.Count;
            }
        }
    }

    private void DoPattern2(float deltaTime)
    {
        if ((transform.position - positionsPossible[currentTargetPos]).magnitude > epsilon)
        {
            transform.position -= (transform.position - positionsPossible[currentTargetPos]).normalized * speed * deltaTime;
        }
        else
        {
            if (nbShootFaitPdtAttaque <= nbTirParAttaque*2)
            {
                timeSinceLastShoot += deltaTime;
                if (timeSinceLastShoot > delaiEntreAttaques/2)
                {
                    GameObject go1 = Instantiate(missilePrefab, shootingPositions[currentShootingPosUsed].position, shootingPositions[currentShootingPosUsed].rotation, bulletContainer);
                    go1.GetComponent<Rigidbody2D>().velocity = shootingPositions[currentShootingPosUsed].forward * bulletSpeed;
                    nbShootFaitPdtAttaque++;
                    //on change les positions d'attaque utilisées.
                    currentShootingPosUsed++;
                    currentShootingPosUsed %= shootingPositions.Length;
                }
            }
            else
            {
                currentTargetPos++;
                currentTargetPos %= positionsPossible.Count;
            }
        }
    }

    public void SetActif()
    {
        actif = true;
    }
}
