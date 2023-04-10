using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mini1
{

    public class controller : MonoBehaviour
    {
        [SerializeField] gamemanager gm;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                select();
            }
        }
        public void select()
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit);
            Debug.Log(raycastHit.transform.name);
            if (raycastHit.transform != null)
            {
                if (raycastHit.transform.tag == "hedef")
                {
                    Destroy(raycastHit.transform.gameObject);
                    gm.scoreUp();
                }
            }
        }
    }
}
