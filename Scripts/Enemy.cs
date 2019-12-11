using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 4;

    [SerializeField] private float maxHealth = 4;

    [SerializeField] private GameObject text;

    [SerializeField] private int pointValue;

    [SerializeField] private Animator destroyed;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private enum type {WOOD, STONE};

    private int scoreValue = 100;

    [SerializeField] private type typeMat;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    private void Update()
    {
        if (text != null)
        {
            text.transform.position = transform.position;
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
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            text = Instantiate(ScoreManager.instance.PointTxt, canvas.transform, true);
            text.transform.position = transform.position;
            Destroy(text, 0.3f);
            ScoreManager.instance.ScoreValue += scoreValue;

            if (typeMat == type.STONE)
            {
                GetComponent<Animator>().Play("SteenKapot");
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject,1);
    }
}
