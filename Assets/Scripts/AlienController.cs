using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float moveSpeed = 3f;
    public float jumpForce = 4f;

    public KeyCode leftKey;  // Tecla para mover a la izquierda
    public KeyCode rightKey; // Tecla para mover a la derecha
    public KeyCode jumpKey;  // Tecla para saltar

    private bool isJumping = false;  // Para verificar si está en el aire
    private bool isDead = false; // Variable para verificar si el marciano está muerto

    public bool isRedAlien = false;  // Indicador para saber si el alien es rojo
    public bool isBlueAlien = false;  // Indicador para saber si el alien es azul

    public float minX = -18f; // Límite mínimo en el eje X
    public float maxX = 19f;  // Límite máximo en el eje X
    public float minY = -9f;  // Límite mínimo en el eje Y
    public float maxY = 16f;   // Límite máximo en el eje Y

    private int jumpCount = 0;  // Para contar los saltos (0 = en el suelo, 1 = primer salto, 2 = doble salto)

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;  // Si está muerto, no procesamos más entradas (detenemos el movimiento)

        // Verificar si el alien está fuera de los límites
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            Die();  // Matar al alien si está fuera de los límites
            return; // Evitar que el alien siga procesando el movimiento
        }

        float move = 0;

        // Detectar el movimiento según las teclas asignadas
        if (Input.GetKey(leftKey))
            move = -1;
        else if (Input.GetKey(rightKey))
            move = 1;

        // Movimiento horizontal
        if (move != 0)
        {
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y); // Movimiento físico
            animator.SetBool("isRunning", true);

            // Invertir la dirección del sprite según el movimiento, sin cambiar el tamaño
            if (move > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Orientación normal (derecha)
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Invertir en el eje X (izquierda)
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Salto
        if (Input.GetKeyDown(jumpKey))
        {
            if (jumpCount < 2) // Permitir salto si el contador de saltos es menor que 2
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Fuerza de salto
                animator.SetBool("isJumping", true); // Cambiar a animación de salto
                jumpCount++; // Incrementar el contador de saltos
            }
        }

        // Transición entre salto y caída
        if (rb.velocity.y < 0 && isJumping)
        {
            animator.SetBool("isJumping", false); // Termina la animación de salto
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
        // Si el alien es azul y colide con "fire"
        else if (isBlueAlien && collision.collider.CompareTag("Fire"))
        {
            Die();
        }
        // Si colisiona con el suelo, restablecer el contador de saltos
        else if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false; // El alien está en el suelo
            animator.SetBool("isJumping", false); // Termina la animación de salto
            jumpCount = 0;  // Restablecer el contador de saltos cuando toque el suelo
        }
    }

    void Die()
    {
        if (isDead) return; // Si ya está muerto, no hacer nada más

        isDead = true;
        animator.SetBool("isDead", true); // Cambiar a la animación de muerte

        // Detener el movimiento del alien
        rb.velocity = Vector2.zero; // Detener movimiento
        rb.isKinematic = true; // Desactivar la física (para que no se siga moviendo)
    }
}
