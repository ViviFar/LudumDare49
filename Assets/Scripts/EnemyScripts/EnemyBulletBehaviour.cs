using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    [SerializeField]
    protected int damage = 2;
    [SerializeField]
    private bool hasDestroyAnimation = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 7) && gameObject.layer == 9)
        {
            //si c'est le tir d'un ennemi qui se touche lui même, on ignore
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit target");
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (collision.gameObject.tag != "wall")
        {

            Debug.Log("hit " + collision.gameObject.name);
            if (!hasDestroyAnimation)
            {
                Destroy(this.gameObject);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2();
                GetComponent<Animator>().SetBool("IsExploding", true);
                Destroy(gameObject, 0.5f);
            }
        }
        else
        {
            Debug.Log("hit wall");
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2();
    }
}
