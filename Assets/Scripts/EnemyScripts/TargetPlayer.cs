using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsPaused)
        {
            if (player != null)
            {
                Vector3 target = player.transform.position - transform.position;
                float angletarget = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + Random.Range(-5, 5);
                transform.rotation = Quaternion.Euler(0, 0, angletarget);
            }
        }
    }
}
