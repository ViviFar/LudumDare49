using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    //pour choisir le type d'attaque que le joueur pourra utiliser
    private PlayerStatus status;

    //à bloquer si le joueur est en status solide car il s'agit d'un charge (légèrement modifiable via controle)
    private PlayerMovement playerMovement;

    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (status.CurrentPlayerState == PlayerState.Solide)
        {
            Debug.Log("fin de l'état solide, retour au neutre");
            //TODO: si la collision est avec un ennemi, faire des dégats à l'ennemi + frame d'invulnérabilité pour pas qu'il prenne du dégat juste après
            status.CurrentPlayerState = PlayerState.Neutral;
        }
        else
        {
            //TODO: si c'est un ennemi ou un projectile, le joueur prend du dégat
        }
    }
}
