using UnityEngine;

public class ButtonMechanism : MonoBehaviour
{
    public Transform blockToMove;          // Bloque que se moverá
    public Vector3 targetPosition;        // Nueva posición del bloque
    public float moveSpeed = 2f;          // Velocidad del movimiento

    private bool isActivated = false;     // Indica si el botón fue activado
    private bool hasReachedTarget = false; // Controla si el bloque llegó al objetivo

    private Rigidbody2D rb;

    void Start()
    {
        rb = blockToMove.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("El bloque necesita un Rigidbody2D.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el botón fue activado por un objeto con el tag "Alien"
        if (collision.CompareTag("Alien") && !hasReachedTarget)
        {
            Debug.Log("Botón activado por: " + collision.name);
            isActivated = true;

            // Desactiva temporalmente la gravedad
            if (rb != null)
            {
                rb.gravityScale = 0; // Sin gravedad mientras se mueve
                rb.velocity = Vector2.zero; // Detén cualquier movimiento residual
            }
        }
    }

    void Update()
    {
        if (isActivated)
        {
            // Mueve el bloque hacia la posición objetivo
            blockToMove.position = Vector3.MoveTowards(blockToMove.position, targetPosition, moveSpeed * Time.deltaTime);

            // Comprueba si el bloque llegó al destino
            if (blockToMove.position == targetPosition)
            {
                Debug.Log("Bloque alcanzó la posición objetivo.");
                isActivated = false;
                hasReachedTarget = true;

                // Mantén el bloque fijo sin eliminar el Rigidbody
                if (rb != null)
                {
                    rb.gravityScale = 0; // Desactiva la gravedad para mantenerlo fijo
                }
            }
        }
    }

    public void ResetBlock(Vector3 newTargetPosition)
    {
        // Reactiva el bloque para moverse a una nueva posición
        targetPosition = newTargetPosition;
        hasReachedTarget = false;

        if (rb != null)
        {
            rb.gravityScale = 1; // Reactiva la gravedad si fuera necesario
        }

        Debug.Log("El bloque está listo para moverse a una nueva posición.");
    }
}
