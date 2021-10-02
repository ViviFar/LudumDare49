using System;
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
        anim.SetBool("IsGazeux", false);
        anim.SetBool("IsLiquid", false);
    }

    public void LaunchSolide()
    {
        anim.SetBool("IsSolid", true);
    }

    public void LaunchLiquide()
    {
        anim.SetBool("IsLiquid", true);
    }

    public void LaunchGazeux()
    {
        anim.SetBool("IsGazeux", true);
    }
}
