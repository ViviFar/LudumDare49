using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetNeutral()
    {
        anim.SetBool("IsSolid", false);
    }

    public void LaunchSolid()
    {
        anim.SetBool("IsSolid", true);
    }
}
