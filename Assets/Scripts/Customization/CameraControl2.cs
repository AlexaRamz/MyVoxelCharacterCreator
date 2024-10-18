using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    public bool canRotate;
    public GameObject target;
    Vector3 point;
    public float speedMod = 10.0f;

    Vector3 mousePos;
    public float shift;

    public GameObject cSystem;

    void Start()
    {
        canRotate = true;

        point = target.transform.position;
        transform.LookAt(point);

        mousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }
    void Update()
    {
        //next: prevent mouse from doing this while over button
        if (cSystem.GetComponent<Customization>().tool == "MouseTool")
        {
            canRotate = true;
        }
        else
        {
            canRotate = false;
        }

        if (canRotate == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x >= mousePos.x + shift)
                {
                    transform.RotateAround(point, -Vector3.up, 10 * Time.deltaTime * speedMod);
                }
                if (Input.mousePosition.x <= mousePos.x - shift)
                {
                    transform.RotateAround(point, Vector3.up, 10 * Time.deltaTime * speedMod);
                }
                if (Input.mousePosition.y >= mousePos.y + shift)
                {
                    transform.RotateAround(point, transform.right, 10 * Time.deltaTime * speedMod);
                }
                if (Input.mousePosition.y <= mousePos.y - shift)
                {
                    transform.RotateAround(point, -transform.right, 10 * Time.deltaTime * speedMod);
                }
            }
        }
    }
}
