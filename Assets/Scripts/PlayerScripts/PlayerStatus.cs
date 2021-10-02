using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Neutral = 0,
    Liquide = 1,
    Solide = 2,
    Gazeux = 3
}

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private PlayerState currentPlayerState;
    public PlayerState CurrentPlayerState
    {
        get { return currentPlayerState; }
        set
        {
            if(currentPlayerState != value)
            {
                currentPlayerState = value;
            }
        }
    }

    private Vector3 solideDirection;
    public Vector3 SolideDirection
    {
        get { return solideDirection; }
    }

    [SerializeField]
    private float liquideTimer = 10;

    [SerializeField]
    private float gazeuxTimer = 10;

    private float timerSinceChange = 0;
    private Camera cam;
    private PlayerAnimation anim;

    private void Start()
    {
        cam = Camera.main;
        anim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        timerSinceChange += Time.deltaTime;
        if((currentPlayerState == PlayerState.Gazeux && timerSinceChange>= gazeuxTimer) || (currentPlayerState == PlayerState.Liquide && timerSinceChange >= liquideTimer))
        {
            Debug.Log("switching back to neutral state");
            currentPlayerState = PlayerState.Neutral;
        }
        else if (currentPlayerState == PlayerState.Neutral)
        {
            if (anim != null)
            {
                anim.ResetNeutral();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (anim != null)
                {
                    anim.LaunchLiquide();
                }
                Debug.Log("going into liquid");
                currentPlayerState = PlayerState.Liquide;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (anim != null)
                {
                    anim.LaunchGazeux();
                }
                Debug.Log("going into gazeux");
                currentPlayerState = PlayerState.Gazeux;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (anim != null)
                {
                    anim.LaunchSolide();
                }
                solideDirection = (cam.ScreenToWorldPoint(Input.mousePosition)-transform.position).normalized;
                Debug.Log("going into solid, targeting : " + cam.ScreenToWorldPoint(Input.mousePosition));
                currentPlayerState = PlayerState.Solide;
            }
        }
    }
}
