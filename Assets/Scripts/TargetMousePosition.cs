using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMousePosition : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        float angletarget =  Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angletarget);
    }
}
