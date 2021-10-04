using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    private float invincibiliteDuration = 2;
    private PlayerStatus status;
    private SpriteRenderer sprite;
    private CapsuleCollider2D col;

    [SerializeField]
    public AudioClip hurtSound;

    private Color colorRed, colorNormal;
    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        sprite = GetComponent<SpriteRenderer>();
        colorNormal = new Color(1, 1, 1);
        colorRed = new Color(1, 0, 0);
        col = GetComponent<CapsuleCollider2D>();
    }

    public override void TakeDamage(int damage)
    {
        transform.GetComponent<AudioSource>().clip = hurtSound;
        transform.GetComponent<AudioSource>().Play();

        if (status.CurrentPlayerState == PlayerState.Solide)
        {
            base.TakeDamage(1);
        }
        else{
            base.TakeDamage(damage);
        }
        if (health <= 0)
        {
            LevelManager.Instance.ShowDefeatPanel();
            Destroy(this.gameObject);
        }
        LevelManager.Instance.UpdateHealthUI(health);
        LaunchInvincibilite(invincibiliteDuration);
    }

    public void LaunchInvincibilite(float duration)
    {
        StartCoroutine(Invincibilite(duration));
    }

    private IEnumerator Invincibilite(float duration)
    {
        isInvincible = true;
        float timer = 0;
        bool isRed = false;
        while (timer < duration)
        {
            timer += 0.5f;
            if (isRed)
            {
                sprite.color = colorNormal;
            }
            else
            {
                sprite.color = colorRed;
            }
            isRed = !isRed;
            yield return new WaitForSeconds(0.5f);
        }
        sprite.color = colorNormal;
        isInvincible = false;
    }
}
