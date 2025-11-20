using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float maxRotation = 30f;
    [SerializeField] private float minRotation = -90f;

    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (isDead) return;

        // Jump on spacebar or mouse click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        // Rotate bird based on velocity
        RotateBird();
    }

    void Jump()
    {
        if (rb == null) return;

        // Reset velocity and apply upward force
        rb.velocity = Vector2.zero;
        rb.velocity = Vector2.up * jumpForce;
    }

    void RotateBird()
    {
        if (rb == null) return;

        // Calculate rotation based on velocity
        float rotation = 0f;

        if (rb.velocity.y > 0)
        {
            rotation = maxRotation;
        }
        else
        {
            rotation = Mathf.Lerp(maxRotation, minRotation, -rb.velocity.y / 10f);
        }

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }
}

