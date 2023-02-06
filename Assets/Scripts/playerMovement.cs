using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject playerCapsule;
    public Rigidbody rb;
    [SerializeField] private int speed;
    [SerializeField]private Transform playerEye;
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float camlimitMin;
    [SerializeField] private float camlimitMax;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode sprintKey;
    [SerializeField] private int sprintSpeed;
    [SerializeField] private int currentSpeed;
    [SerializeField] private float interactRange;

    private float camAngle = 0.0f;
    private void Start()
    {
        currentSpeed = speed;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        sprintCheck();
        mouseLook();
        RotateBody();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void RotateBody()
    {
        float xMouse = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * xMouse);
    }

    private void sprintCheck()
    {
        if (Input.GetKey(sprintKey))
        {
            currentSpeed = speed + sprintSpeed;
        }

        if (Input.GetKeyUp(sprintKey))
        {
            currentSpeed = speed;
        }
    }

    private void TryInterat()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerEye.position, playerEye.forward, out hit, interactRange)){
            IInteractable.

        }
    }
    private void TryJump()
    {
        if (isGrounded())
        {
            Jump(jumpForce);
        }
    }
    private bool isGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, -transform.up, out hit, 1.1f);
    }
    private void Jump(float jumpForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up* jumpForce, ForceMode.Impulse);
    }
    void mouseLook()
    {
        float yMouse = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        playerEye.localRotation = Quaternion.Euler(camAngle, 0, 0);
        camAngle -= yMouse;
        camAngle = Mathf.Clamp(camAngle, camlimitMin, camlimitMax);

    }
    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * xDir + transform.forward * zDir;

        rb.velocity = new Vector3(0, rb.velocity.y, 0) + dir.normalized * currentSpeed;
    }
}
