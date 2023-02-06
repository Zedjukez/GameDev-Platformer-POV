using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject playerCapsule;
    public Rigidbody playerBody;
    public Vector3 rawMovement;
    [SerializeField] private int speed;
    [SerializeField]private Transform playerEye;
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float camlimitMin;
    [SerializeField] private float camlimitMax;

    private float camAngle = 0.0f;
    private void Update()
    {
        mouseLook();
        Movement();
        transform.Translate(rawMovement * speed * Time.deltaTime);

    }

    private void RotateBody()
    {
        float xMouse = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * xMouse);
    }
    void mouseLook()
    {
        float yMouse = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        playerEye.localRotation = Quaternion.Euler(camAngle, 0, 0);
        camAngle -= yMouse;
        camAngle = Mathf.Clamp(camAngle, camlimitMin, camlimitMax);

    }
    void Movement()
    {
        if (Input.GetKeyDown("w"))
        {
            rawMovement.z += 2;
        }
        if (Input.GetKeyDown("s"))
        {
            rawMovement.z += -2;

        }
        if (Input.GetKeyDown("d"))
        {
            rawMovement.x += 2;
        }
        if (Input.GetKeyDown("a"))
        {
            rawMovement.x += -2;

        }
    }
}
