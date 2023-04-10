using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Transform draggedObject;
    public string selectableTag = "Potion";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag(selectableTag))
            {
                draggedObject = hit.transform;
                isDragging = true;
                offset = draggedObject.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggedObject.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, draggedObject.position.z);
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            draggedObject = null;
        }
    }
}
