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
        Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        transform.localPosition = target.normalized * 3;
        Quaternion rot = Quaternion.LookRotation(-target, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
