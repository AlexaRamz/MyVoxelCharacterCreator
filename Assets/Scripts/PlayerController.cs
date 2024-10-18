using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool plrActive;
    Camera mainCamera;
    public float speed;
    public float jumpSpeed;

    Rigidbody rb;

    Ray ray;
    RaycastHit hit;

    float camShift;

    void Start()
    {
        plrActive = true;
        mainCamera = Camera.main;
        camShift = -9f;
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        if (plrActive == true)
        {
            Vector3 plrPos = transform.position;
            mainCamera.transform.position = new Vector3(plrPos.x, mainCamera.transform.position.y, plrPos.z + camShift);
        }
    }
    void FixedUpdate()
    {
        if (plrActive == true)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
                //transform.rotation = Quaternion.LookRotation(movement);
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("space"))
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
            }
        }
    }
}