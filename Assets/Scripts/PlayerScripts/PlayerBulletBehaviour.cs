using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehaviour : MonoBehaviour
{
    [SerializeField]
    protected int damage = 2;
    [SerializeField]
    private bool isAirAttack = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.layer == 3 || collision.gameObject.layer == 7 || collision.gameObject.layer == 9) && gameObject.layer == 7)
        {
            //de même si c'est le tir d'un joueur qui touche le joueur
            return;
        }

        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("hit target");
            collision.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            if (isAirAttack)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2();
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag!= "CameraTeleport" && collision.gameObject.tag != "SpawnPoint")
        {
            Debug.Log("hit " + collision.gameObject.name);
            if (isAirAttack)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2();
                GetComponent<Animator>().SetBool("IsExploding", true);
                Destroy(gameObject, 0.5f);
            }
        }
        else
        {
            Debug.Log("hit wall " + collision.gameObject.name);
        }
    }
}
