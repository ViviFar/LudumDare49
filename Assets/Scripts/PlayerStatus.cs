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

    [SerializeField]
    private float liquideTimer = 10;

    [SerializeField]
    private float gazeuxTimer = 10;

    private float timerSinceChange = 0;

    private void Update()
    {
        timerSinceChange += Time.deltaTime;
        if(currentPlayerState == PlayerState.Gazeux && timerSinceChange>= gazeuxTimer)
        {
            currentPlayerState = PlayerState.Neutral;
        }
        else if (currentPlayerState == PlayerState.Liquide && timerSinceChange >= liquideTimer)
        {
            currentPlayerState = PlayerState.Neutral;
        }
        else if (currentPlayerState == PlayerState.Neutral)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentPlayerState = PlayerState.Liquide;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentPlayerState = PlayerState.Gazeux;
                timerSinceChange = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentPlayerState = PlayerState.Solide;
            }
        }
    }
}
