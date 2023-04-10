using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Spell : MonoBehaviour
{
    private Transform target;
    private Vector3 direction;
    public float speed;

    private void Awake()
    {
        target = GameObject.Find("Crosshair").transform;
        direction = (target.position - transform.position).normalized;
        
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
