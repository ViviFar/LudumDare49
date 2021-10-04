using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamera : MonoBehaviour
{
    private Camera cam;
    
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            GetComponent<EnemySpawner>().Spawn();
        }
    }
}
