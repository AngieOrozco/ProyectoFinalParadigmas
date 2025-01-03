using UnityEngine;

public class AlienController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private Animator animator; // Referencia al Animator
    private bool isGrounded = false; // Comprobar si está en el suelo

    void Start()
    {
        // Inicializar referencias
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Actualizar animación de caminar
        if (move != 0)
        {
            animator.SetBool("isWalking", true);
            // Cambiar la dirección del sprite
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
