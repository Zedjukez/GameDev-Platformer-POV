using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    // Public variables
    public float grappleSpeed = 10f;
    public float maxDistance = 100f;
    public LayerMask grappleMask;
    public Transform grapplePoint;
    public AudioSource grappleSound;

    // Private variables
    private LineRenderer lineRenderer;
    private Rigidbody rb;
    private bool isGrappling = false;
    private Vector3 grappleTarget;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(grapplePoint.position, grapplePoint.forward * maxDistance, Color.green);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isGrappling)
            {
                StopGrapple();
            }
            else
            {
                StartGrapple();
            }
        }

        if (isGrappling)
        {
            lineRenderer.SetPosition(0, grapplePoint.position);
            lineRenderer.SetPosition(1, grappleTarget);

            Vector3 grappleDirection = (grappleTarget - transform.position).normalized;
            rb.velocity = grappleDirection * grappleSpeed;

            float distanceToGrappleTarget = Vector3.Distance(transform.position, grappleTarget);
            if (distanceToGrappleTarget <= 1f)
            {
                StopGrapple();
            }
        }
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(grapplePoint.position, grapplePoint.forward, out hit, maxDistance, grappleMask))
        {
            grappleTarget = hit.point;
            isGrappling = true;
            lineRenderer.enabled = true;
            grappleSound.Play();
        }
    }

    void StopGrapple()
    {
        isGrappling = false;
        lineRenderer.enabled = false;
        rb.velocity = Vector3.zero;
    }
        
}
