using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Etats
{
    Menu = 0,
    EnJeu =1,
    Perdu = 2,
    Gagne = 3
}

public class GameManager : GenericSingleton<GameManager>
{
    [SerializeField]
    private Etats currentState = Etats.Menu;
    public Etats CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
        }
    }

    private Etats previousState = Etats.Menu;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (previousState != currentState)
        {
            switch (currentState)
            {
                case Etats.Menu:
                    OnMenuStateEnter();
                    break;
                case Etats.EnJeu:
                    OnEnJeuStateEnter();
                    break;
                case Etats.Gagne:
                    OnGagneStateEnter();
                    break;
                case Etats.Perdu:
                    OnPerduStateEnter();
                    break;
                default:
                    break;
            }
            previousState = currentState;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentState = Etats.Perdu;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentState = Etats.Gagne;
        }
#endif
    }

    private void OnMenuStateEnter()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnJeuStateEnter()
    {
        SceneManager.LoadScene(1);
    }

    private void OnGagneStateEnter()
    {
        //show Victory screen
    }

    private void OnPerduStateEnter()
    {
        //show defaite screen
    }
}
