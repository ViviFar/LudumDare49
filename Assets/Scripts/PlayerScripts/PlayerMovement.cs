using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //vitesse normale (ie dans les états autres que celui solide)
    [SerializeField]
    private float speed = 10;

    //vitesse lorsque le joueur est en mode solide (glaçon)
    [SerializeField]
    private float solideSpeed = 14;

    private PlayerStatus status;

    //pour reset le jeu
    private Vector3 startingPlayerPos;
    private Quaternion startingPlayerRot;

    private PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        startingPlayerPos = transform.position;
        startingPlayerRot = transform.rotation;
        status = GetComponent<PlayerStatus>();
        health = GetComponent<PlayerHealth>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (status.CurrentPlayerState != PlayerState.Solide)
        {
            Vector2 newPos = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime);
            transform.position = newPos;
        }
        else
        {
            Vector2 newPos = transform.position + status.SolideDirection * solideSpeed * Time.deltaTime;
            transform.position = newPos;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (status.CurrentPlayerState == PlayerState.Solide)
        {
            //TODO: si la collision est avec un ennemi, faire des dégats à l'ennemi + frame d'invulnérabilité pour pas qu'il prenne du dégat juste après
            switch (collision.gameObject.tag)
            {
                case "enemy":
                    Debug.Log("do damage");
                    if (health != null)
                    {
                        health.LaunchInvincibilite(1);
                    }
                    Debug.Log("fin de l'état solide, retour au neutre");
                    status.CurrentPlayerState = PlayerState.Neutral;
                    break;
                case "projectile":
                    Debug.Log("projectile pris");
                    if (health != null)
                    {
                        health.TakeDamage(1);
                    }
                    break;
                case "wall":
                    Debug.Log("mur rencontré, retour à l'état neutre");
                    status.CurrentPlayerState = PlayerState.Neutral;
                    Debug.Log("fin de l'état solide, retour au neutre");
                    break;
                default:
                    break;
            }
        }
        else
        {
            //TODO: si c'est un ennemi ou un projectile, le joueur prend du dégat      
            switch (collision.gameObject.tag)
            {
                case "enemy":
                case "projectile":
                    if (status.CurrentPlayerState == PlayerState.Gazeux)
                    {
                        health.TakeDamage(4);
                    }
                    else
                    {
                        health.TakeDamage(2);
                    }
                    break;
            }
        }
    }
}
