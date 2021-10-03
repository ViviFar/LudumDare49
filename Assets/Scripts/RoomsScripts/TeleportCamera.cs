using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamera : MonoBehaviour
{
    private Camera camera;
    
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered the trigger");
        if (other.CompareTag("Player"))
        {
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
