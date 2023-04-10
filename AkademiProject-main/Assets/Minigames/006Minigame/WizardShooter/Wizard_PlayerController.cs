using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_PlayerController : MonoBehaviour
{
    public float gameLength = 10f;
    public float currentStreak = 0f;

    public bool isGameEnded = false;

    private Rigidbody2D rb;

    public Animator animator;
    public Transform animatedTransform;

    public float speed;
    private float moveX;
    private float moveY;

    private WizardShooterController wizardShooterController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wizardShooterController = GameObject.Find("WizardShooter_Controller").GetComponent<WizardShooterController>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX*speed, moveY*speed);

        if (currentStreak >= 10)
        {
            isGameEnded = true;

            wizardShooterController.WizardShooterCompleted();
        }

        if(moveX != 0 || moveY != 0)
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
        if (collision.transform.CompareTag("Enemy"))
        {
            isGameEnded = true;
            wizardShooterController.WizardShooterFailed();
        }
    }
}
