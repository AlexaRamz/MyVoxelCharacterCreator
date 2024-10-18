using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool canRotate;
    public GameObject target;
    public float speedMod = 10.0f;

    float minDistance = 2;
    float maxDistance = 15;

    void Start()
    {
   
    }
    public void CamOn()
    {
        canRotate = true;
        GetComponent<Camera>().enabled = true;
    }
    public void CamOff()
    {
        canRotate = false;
        GetComponent<Camera>().enabled = false;
    }
    void Update()
    {
        Vector3 point = target.transform.position;
        transform.LookAt(point);

        if (canRotate == true)
        {
            Vector3 direction = transform.position - point;
            
            if (direction.magnitude > minDistance)
            {
                if (Input.GetKey("w") || Input.GetKey("up"))
                {
                    Vector3 cameraMove = Vector3.forward * speedMod;
                    transform.Translate(cameraMove * Time.deltaTime);
                }
            }
            if (direction.magnitude < maxDistance)
            {
                if (Input.GetKey("s") || Input.GetKey("down"))
                {
                    Vector3 cameraMove = -Vector3.forward * speedMod;
                    transform.Translate(cameraMove * Time.deltaTime);
                }
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                transform.RotateAround(point, -Vector3.up, 10 * Time.deltaTime * speedMod);
            }
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                transform.RotateAround(point, Vector3.up, 10 * Time.deltaTime * speedMod);
            }
            if (Input.GetKey("e"))
            {
                transform.RotateAround(point, transform.right, 10 * Time.deltaTime * speedMod);
            }
            if (Input.GetKey("q"))
            {
                transform.RotateAround(point, -transform.right, 10 * Time.deltaTime * speedMod);
            }

            if (Input.GetMouseButton(1))
            {
                float rotx = Input.GetAxis("Mouse X") * 1.5f * speedMod;
                float roty = Input.GetAxis("Mouse Y") * 1.5f * speedMod;
                
                transform.RotateAround(point, Vector3.up, rotx);
                transform.RotateAround(point, transform.right, -roty);
            }
        }
    }
}
