using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 4;

    [SerializeField] private float maxHealth = 4;

    [SerializeField] private int pointValue;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    void ChangeTheSprite(int spriteNum)
    {
        spriteRenderer.sprite = sprites[spriteNum];
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        health -= colInfo.relativeVelocity.magnitude;

        if (health < maxHealth / 2 && sprites.Count == 2)
        {
            ChangeTheSprite(1);
        }
        else if (health < maxHealth / 3 * 2 && sprites.Count == 3)
        {
            ChangeTheSprite(1);
        }
        else if (health < maxHealth / 3 && sprites.Count == 3)
        {
            ChangeTheSprite(2);
        }

        if (health < 0)
        {
            Die();
        }
        //Debug.Log(colInfo.relativeVelocity.magnitude);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
