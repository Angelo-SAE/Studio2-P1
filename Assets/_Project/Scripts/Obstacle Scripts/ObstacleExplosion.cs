using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplosion : MonoBehaviour
{
    public float explosionForce = 1000f; // The force of the explosion
    public float explosionRadius = 5f; // The radius within which the explosion affects other objects
    public float minDelay = 3f; // Minimum delay before explosion
    public float maxDelay = 5f; // Maximum delay before explosion

    private float countdown;
    private bool hasExploded = false;

    void Start()
    {
        // Set a random countdown timer between minDelay and maxDelay
        countdown = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        // Decrement the countdown timer
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true; // Ensure it only explodes once
        }
    }

    void Explode()
    {
        // You can add an explosion effect instantiation here if you have one

        // Detect players within the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && nearbyObject.CompareTag("Player")) // Ensure it affects only players
            {
                // Apply explosion force
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                Debug.Log("EXPLOSION");
            }
        }

        // Optionally destroy the obstacle after exploding
        Destroy(gameObject);
    }
}
