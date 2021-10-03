using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    [SerializeField]
    private int damage = 2;
    [SerializeField]
    private bool hasDestroyAnimation = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit something");
        if (collision.gameObject.tag == targetTag)
        {
            Debug.Log("hit target");
            collision.transform.GetComponent<Health>().TakeDamage(damage);
        }
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
    
}
