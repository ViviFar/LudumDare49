using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    //pour choisir le type d'attaque que le joueur pourra utiliser
    private PlayerStatus status;

    //� bloquer si le joueur est en status solide car il s'agit d'un charge (l�g�rement modifiable via controle)
    private PlayerMovement playerMovement;

    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        
    }
}
