using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    private Vector3 startingPlayerPos;
    private Quaternion startingPlayerRot;

    // Start is called before the first frame update
    void Start()
    {
        startingPlayerPos = transform.position;
        startingPlayerRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        transform.position = newPos;
    }
}
