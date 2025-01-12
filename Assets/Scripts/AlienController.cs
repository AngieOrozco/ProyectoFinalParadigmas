using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float moveSpeed = 3f;
    public float jumpForce = 4f;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    private bool isJumping = false;
    public bool isDead = false;

    public bool isRedAlien = false;
    public bool isBlueAlien = false;

    public float minX = -18f;
    public float maxX = 19f;
    public float minY = -9f;
    public float maxY = 16f;

    private int jumpCount = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            Die();
            return;
        }

        float move = 0;

        if (Input.GetKey(leftKey))
            move = -1;
        else if (Input.GetKey(rightKey))
            move = 1;

        if (move != 0)
        {
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
            animator.SetBool("isRunning", true);

            if (move > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(jumpKey))
        {
            if (jumpCount < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("isJumping", true);
                jumpCount++;
            }
        }

        if (rb.velocity.y < 0 && isJumping)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Acid") || collision.collider.CompareTag("Acid2"))
        {
            Die();
        }
        else if (isRedAlien && collision.collider.CompareTag("Water"))
        {
            Die();
        }
        else if (isBlueAlien && collision.collider.CompareTag("Fire"))
        {
            Die();
        }
        else if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            jumpCount = 0;
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetBool("isDead", true);

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
