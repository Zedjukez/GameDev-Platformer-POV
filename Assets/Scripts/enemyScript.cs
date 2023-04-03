using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    [SerializeField] private float shootRange = 10f; // The range at which the enemy can see the player and shoot
    [SerializeField] private float shootSpeed = 20f; // The speed at which the sphere prefab is shot
    [SerializeField] private GameObject spherePrefab; // The prefab that will be shot by the enemy
    [SerializeField] private float sphereLifetime = 5f; // The amount of time the sphere prefab will exist before being destroyed
    private GameObject player; // Reference to the player GameObject


    public enemyStats stats;
    private Animator animator;
    private Vector3 startPos;
    private Vector3 endPos;

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("enemyIdle"))
            {
                float t = 0;
                startPos = transform.position;
                endPos = new Vector3(transform.position.x, 5.2f, transform.position.z);
                while (t < 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPos, endPos, t);
                    yield return null;
                }
                t = 0;
                startPos = endPos;
                endPos = new Vector3(transform.position.x, 5f, transform.position.z);
                while (t < 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPos, endPos, t);
                    yield return null;
                }
            }
            yield return null;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        StartCoroutine(MoveUpDown());
    }

    float t = 0;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= shootRange)
        {
            t += Time.deltaTime;
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Rotate the enemy to face the player
            transform.rotation = Quaternion.LookRotation(direction);
            if (t > sphereLifetime)
            {
                t = 0;
                // Shoot a sphere prefab in the direction of the player
                GameObject sphere = Instantiate(spherePrefab, transform.position + new Vector3(1.5f, 0f, 0f), Quaternion.identity);
                Rigidbody sphereRb = sphere.GetComponent<Rigidbody>();
                SphereCollider sphereCollider = sphere.GetComponent<SphereCollider>();
                sphereCollider.radius = 0.16f;
                sphereCollider.isTrigger = true;
                sphereRb.velocity = direction * shootSpeed;

                // Destroy the sphere after a set amount of time
                Destroy(sphere, sphereLifetime);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the sphere hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("levelOne");
        }
        }
}

