using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public int nbEnemyToSpawnMin = 3;
    [SerializeField]
    public int nbEnemyToSpawnMax = 6;
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    [SerializeField]
    private List<GameObject> doors;
    [SerializeField]
    public bool boss = false;

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
        if (boss)
        {
            if(LevelManager.Instance.Boss != null)
            {
                LevelManager.Instance.Boss.SetActif();
            }
        }
        if (!spawned)
        {
            col.enabled = false;
            int nbEnemyToSpawn = Random.Range(nbEnemyToSpawnMin, nbEnemyToSpawnMax + 1);
            currentNbEnemy = nbEnemyToSpawn;
            for (int i = 0; i < nbEnemyToSpawn; i++)
            {
                int typeEnemy = Random.Range(0, enemyPrefabs.Count);
                int xRand = Random.Range(-3, 3);
                int yRand = Random.Range(-3, 3);
                if (Mathf.Abs(xRand) > 1 && Mathf.Abs(yRand) < 2)
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
            if (currentNbEnemy == 0)
            {
                col.enabled = true;
            }
        }

        foreach (GameObject go in doors)
        {
            go.SetActive(currentNbEnemy != 0 || boss);
        }
    }

    public void OnEnemyDeath()
    {
        currentNbEnemy--;
        if (currentNbEnemy == 0 && !boss)
        {
            col.enabled = true;
            foreach (GameObject go in doors)
            {
                go.SetActive(false);
            }
        }
    }
}
