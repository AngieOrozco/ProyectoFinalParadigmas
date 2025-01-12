using UnityEngine;

public class ButtonMechanism : MonoBehaviour
{
    public Transform blockToMove;
    public Vector3 targetPosition;
    public float moveSpeed = 2f;

    private bool isActivated = false;
    private bool hasReachedTarget = false;

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
        if (collision.CompareTag("Alien") && !hasReachedTarget)
        {
            Debug.Log("Botón activado por: " + collision.name);
            isActivated = true;

            if (rb != null)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
        }
    }

    void Update()
    {
        if (isActivated)
        {
            blockToMove.position = Vector3.MoveTowards(blockToMove.position, targetPosition, moveSpeed * Time.deltaTime);

            if (blockToMove.position == targetPosition)
            {
                Debug.Log("Bloque alcanzó la posición objetivo.");
                isActivated = false;
                hasReachedTarget = true;

                if (rb != null)
                {
                    rb.gravityScale = 0;
                }
            }
        }
    }

    public void ResetBlock(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        hasReachedTarget = false;

        if (rb != null)
        {
            rb.gravityScale = 1;
        }

        Debug.Log("El bloque está listo para moverse a una nueva posición.");
    }
}
