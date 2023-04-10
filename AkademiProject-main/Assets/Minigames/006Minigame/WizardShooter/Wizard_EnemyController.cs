using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_EnemyController : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private float lastPosX;
    private SpriteRenderer spriteRenderer;
    public float speed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);


        float currentPosX = rb.position.x;

        if (currentPosX > lastPosX)
        {
            spriteRenderer.flipX = false;
        }
        else if (currentPosX < lastPosX)
        {
            spriteRenderer.flipX = true;
        }

        lastPosX = currentPosX;



        if (target.GetComponent<Wizard_PlayerController>().isGameEnded)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyHit()
    {
        Destroy(gameObject);
        target.GetComponent<Wizard_PlayerController>().currentStreak++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spell"))
        {
            EnemyHit();
        }
    }
}
