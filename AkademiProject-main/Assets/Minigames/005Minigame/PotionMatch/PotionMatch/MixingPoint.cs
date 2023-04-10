using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingPoint : MonoBehaviour
{
    public GameObject collidingObject;
    public bool isFull;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collidingObject != null)
        {
            return;
        }

        collidingObject = collision.gameObject;
        isFull = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == collidingObject)
        {
            collidingObject = null;
            isFull = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collidingObject != null)
        {
            Debug.Log("Colliding object is: " + collidingObject.name);
        }
    }
}
