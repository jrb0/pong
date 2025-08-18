using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float speed = 10f; // Speed of the ball
    public Vector2 velocity = Vector2.zero; // Initial velocity, not used in this script
    public static event Action OnCollide;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float xVelocity = UnityEngine.Random.Range(-.5f, .5f);
        float yVelocity = UnityEngine.Random.Range(-.5f, .5f);

        Vector2 direction = new Vector2(xVelocity, yVelocity); // Normalize to ensure consistent speed
        rb.linearVelocity = direction.normalized * speed; // Use 'velocity' for Rigidbody2D
        velocity = rb.linearVelocity; // Store the initial velocity
    }

    void Update()
    {
        velocity = rb.linearVelocity; // Update the stored velocity
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            OnCollide.Invoke();
        }
        ;
        Debug.Log("Incoming velocity: " + rb.linearVelocity);

        if (collision.contactCount == 0) return;

        Vector2 normal = collision.GetContact(0).normal;
        Vector2 incoming = rb.linearVelocity;

        // Reflect the incoming velocity around the collision normal
        Vector2 reflected = Vector2.Reflect(incoming, normal);

        // Apply the new velocity
        rb.linearVelocity = reflected.normalized * speed;

        Debug.Log("Reflected velocity: " + rb.linearVelocity);
    }
}