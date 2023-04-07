using UnityEngine;

public class gravWorld : MonoBehaviour
{
    public float gravityMultiplier = 2f; // This is the amount to increase the gravity pull by

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(gravityMultiplier * Physics.gravity, ForceMode.Acceleration);
    }
}
