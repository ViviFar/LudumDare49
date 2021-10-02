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


    // Start is called before the first frame update
    void Start()
    {
        startingPlayerPos = transform.position;
        startingPlayerRot = transform.rotation;
        status = GetComponent<PlayerStatus>();
    }

    bool once = false;

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
            Debug.Log(newPos);
            transform.position = newPos;
        }
    }
}
