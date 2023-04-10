using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mini2
{
    public class controller : MonoBehaviour
    {
        public gamemanager gm;
        Rigidbody rb;
        [SerializeField] float speed = 1f;
        [SerializeField] float force = 1f;
        [SerializeField] Camera cm;
        // Start is called before the first frame update
        void Awake()
        {

            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            move();
            if (Input.GetMouseButtonDown(0))
            {
                rb.AddForce(Vector3.up * force);
            }
        }

        void move()
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            cm.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "engel")
            {
                gm.dead();
            }

        }
    }
}

