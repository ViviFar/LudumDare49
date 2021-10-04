using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int nbEnemyToSpawnMin = 3;
    [SerializeField]
    private int nbEnemyToSpawnMax=6;
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    [SerializeField]
    private List<GameObject> doors;

    private GameObject player;
    private int currentNbEnemy = 0;
    private bool spawned = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Spawn()
    {
        if (!spawned)
        {
            int nbEnemyToSpawn = Random.Range(nbEnemyToSpawnMin, nbEnemyToSpawnMax+1);
            currentNbEnemy = nbEnemyToSpawn;
            for (int i = 0; i < nbEnemyToSpawn; i++)
            {
                int typeEnemy = Random.Range(0, enemyPrefabs.Count);
                int xRand = Random.Range(-3, 3);
                int yRand = Random.Range(-3, 3);
                if (Mathf.Abs(xRand) > 1  && Mathf.Abs(yRand) < 2)
                {
                    xRand = Random.Range(-1, 1);
                }
                if (Mathf.Abs(yRand) > 1 && Mathf.Abs(xRand) < 2)
                {
                    yRand = Random.Range(-1, 1);
                }
                Instantiate(enemyPrefabs[typeEnemy], new Vector3(transform.position.x + xRand, transform.position.y + yRand, 0), transform.rotation, transform);
            }
            spawned = true;
        }

        foreach (GameObject go in doors)
        {
            go.SetActive(currentNbEnemy!=0);
        }
    }

    public void OnEnemyDeath()
    {
        currentNbEnemy--;
        if(currentNbEnemy == 0)
        {
            foreach(GameObject go in doors)
            {
                go.SetActive(false);
            }
        }
    }
}
