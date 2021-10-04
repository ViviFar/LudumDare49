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
    BoxCollider2D col;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<BoxCollider2D>();
    }

    public void Spawn()
    {
        if (!spawned)
        {
            col.enabled = false;
            int nbEnemyToSpawn = Random.Range(nbEnemyToSpawnMin, nbEnemyToSpawnMax+1);
            currentNbEnemy = nbEnemyToSpawn;
            for (int i = 0; i < nbEnemyToSpawn; i++)
            {
                int typeEnemy = Random.Range(0, enemyPrefabs.Count);
                Instantiate(enemyPrefabs[typeEnemy], new Vector3(transform.position.x + i, transform.position.y + i, 0), transform.rotation, transform);
            }
            spawned = true;
            if (currentNbEnemy == 0)
            {
                col.enabled = true;
            }
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
            col.enabled = true;
            foreach(GameObject go in doors)
            {
                go.SetActive(false);
            }
        }
    }
}
