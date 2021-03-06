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
        Debug.Log("entered trigger with " + collision.gameObject.name);
        if ((collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 7) && gameObject.layer == 9)
        {
            //si c'est le tir d'un ennemi qui se touche lui m?me, on ignore
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (collision.gameObject.tag != "CameraTeleport" && collision.gameObject.tag != "SpawnPoint")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2();
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
        }
    }
}
