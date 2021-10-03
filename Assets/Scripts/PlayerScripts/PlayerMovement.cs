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

    [SerializeField]
    private int solideDegats = 10;

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
        transform.rotation = new Quaternion();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (status.CurrentPlayerState == PlayerState.Solide)
        {
            Debug.Log("le joueur en solide tape " + collision.gameObject.tag);
            switch (collision.gameObject.tag)
            {
                case "enemy":
                    collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(solideDegats);
                    if (health != null)
                    {
                        health.LaunchInvincibilite(1);
                    }
                    status.CurrentPlayerState = PlayerState.Neutral;
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
    }

}
