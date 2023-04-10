using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject lock1, lock2, lock3, lock1Reset, lock2Reset, lock3Reset;
    [SerializeField] private Transform combination;
    [SerializeField] private AudioManagerLock audioManager;

    public AudioClip tick;

    public bool hitSomething;

    private string horizontal = "Horizontal";
    private float horizontalInput;
    private Transform lockTransform;
    private Ray ray;
    private CombinationLockController combinationLockController;


    private void Start()
    {
        lockTransform = GetComponent<Transform>();
        float randomX = UnityEngine.Random.Range(0, 360);
        combination.transform.rotation = Quaternion.Euler(0, 0, randomX);
        combinationLockController = GameObject.Find("CombinationLock_Controller").GetComponent<CombinationLockController>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis(horizontal);

        lockTransform.Rotate(Vector3.back * horizontalInput * speed * Time.deltaTime);

        ray = new(lockTransform.position, transform.up);

        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform.name == "L1_Reset")
            {
                lock1.SetActive(true);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
            }

            if (hit.transform.name == "L2_Reset")
            {
                lock1.SetActive(true);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
            }

            if (hit.transform.name == "L3_Reset")
            {
                lock1.SetActive(true);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
            }

            if (hit.transform.name == "L1_True")
            {
                lock1.SetActive(false);
                lock2.SetActive(true);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
                audioManager.PlaySFX(tick, 0.75f);
            }

            if (hit.transform.name == "L1_False")
            {
                lock1.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(true);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
                audioManager.PlaySFX(tick, 0.25f);
            }

            if (hit.transform.name == "L2_True")
            {
                lock1.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(true);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
                audioManager.PlaySFX(tick, 0.75f);
            }

            if (hit.transform.name == "L2_False")
            {
                lock1.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(true);
                lock3Reset.SetActive(false);
                audioManager.PlaySFX(tick, 0.25f);
            }

            if (hit.transform.name == "L3_True")
            {
                lock1.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(false);
                audioManager.PlaySFX(tick, 0.75f);

                combinationLockController.CombinationLockCompleted();
            }

            if (hit.transform.name == "L3_False")
            {
                lock1.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(false);
                lock1Reset.SetActive(false);
                lock2Reset.SetActive(false);
                lock3Reset.SetActive(true);
                audioManager.PlaySFX(tick, 0.25f);
            }
        }
    }
}
