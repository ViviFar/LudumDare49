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
    private float delaiEntreAttaques = .3f;
    [SerializeField]
    private float dureeAttaque = 5;
    [SerializeField]
    private float speed = 5;

    private bool useCardinals = true;

    private Vector3 centralPos;
    List<Vector3> positionsPossible;


    // Update is called once per frame
    void Update()
    {
        if(bossHealth.CurrentHealth >= bossHealth.CurrentHealth / 2)
        {
            DoPattern1();
        }
        else
        {
            DoPattern2();
        }
    }

    private void DoPattern1()
    {
        
    }

    private void DoPattern2()
    {
        throw new NotImplementedException();
    }
}
