using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement3d : MonoBehaviour
{
    //Animator anim;
    public bool plrActive;
    Camera mainCamera;
    public float speed;

    Ray ray;
    RaycastHit hit;

    float camShift;

    void Start()
    {
        plrActive = true;
        mainCamera = Camera.main;
        camShift = -9f;
    }
    void FixedUpdate()
    {
        if (plrActive == true)
        {
            Vector3 plrPos = transform.position;
            mainCamera.transform.position = new Vector3(plrPos.x, mainCamera.transform.position.y, plrPos.z + camShift);

            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 dir = hit.point - transform.position;
                    dir.y = 0;
                    transform.Translate(dir * Time.deltaTime * speed);
                }
            }
        }
    }
}
