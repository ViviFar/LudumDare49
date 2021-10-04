using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    public GameObject bossFloor;

    private void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    // spawn boss
                    Instantiate(bossFloor, rooms[i].transform.position, Quaternion.identity);
                    GameObject go = Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    go.GetComponent<BossShoot>().CentralPos = rooms[i].transform.position;
                    spawnedBoss = true;

                    // deactivate enemies in boss room
                    rooms[i].transform.Find("Room Trigger").gameObject.GetComponent<EnemySpawner>().nbEnemyToSpawnMin = 0;
                    rooms[i].transform.Find("Room Trigger").gameObject.GetComponent<EnemySpawner>().nbEnemyToSpawnMax = 0;
                    rooms[i].transform.Find("Room Trigger").gameObject.GetComponent<EnemySpawner>().boss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
