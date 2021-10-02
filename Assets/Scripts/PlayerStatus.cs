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

    private void Start()
    {
        cam = Camera.main;
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
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("going into liquid");
                currentPlayerState = PlayerState.Liquide;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("going into gazeux");
                currentPlayerState = PlayerState.Gazeux;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                solideDirection = (cam.ScreenToWorldPoint(Input.mousePosition)-transform.position).normalized;
                Debug.Log("direction = " + solideDirection);
                Debug.Log("going into solid, targeting : " + cam.ScreenToWorldPoint(Input.mousePosition));
                currentPlayerState = PlayerState.Solide;
            }
        }
    }
}
