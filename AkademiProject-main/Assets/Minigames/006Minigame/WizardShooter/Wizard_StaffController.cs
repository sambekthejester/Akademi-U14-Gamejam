using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_StaffController : MonoBehaviour
{

    public Transform parent;
    public GameObject crosshair;
    public GameObject spell;
    public Transform spellPos;

    private Vector3 mousePos;
    public float offset;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
     Input.mousePosition.x,
     Input.mousePosition.y,
     transform.position.z
 ));

        crosshair.transform.position = new Vector3(
            mousePos.x,
            mousePos.y,
            transform.position.z
        );

        if (Input.GetMouseButtonDown(0))
        {
            FireSpell();
        }
    }

    private void FixedUpdate()
    {
        float rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    }

    private void FireSpell()
    {
        Instantiate(spell, spellPos.position, Quaternion.identity, parent);
    }
}
