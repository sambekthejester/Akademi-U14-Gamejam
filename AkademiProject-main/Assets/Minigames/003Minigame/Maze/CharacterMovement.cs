using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveX;
    private float moveY;
    public Animator animator;
    public Transform animatedTransform;
    private MazeController mazeController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mazeController = GameObject.Find("Maze_Controller").GetComponent<MazeController>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * speed, moveY * speed);

        if (moveX != 0 || moveY != 0)
        {
            if (moveX < 0)
            {
                animatedTransform.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                animatedTransform.GetComponent<SpriteRenderer>().flipX = false;
            }

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "FinishLine")
        {
            mazeController.MazeCompleted();
        }
    }
}
