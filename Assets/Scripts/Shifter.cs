using UnityEngine;

public class Shifter : MonoBehaviour
{
    public GameObject bloque; // Referencia al bloque con el Collider
    private Collider2D bloqueCollider;  // Referencia al Collider2D del bloque
    private bool activado = false;    // Estado del Shifter

    void Start()
    {
        // Obtener el Collider2D del bloque al principio
        bloqueCollider = bloque.GetComponent<Collider2D>();
    }

    // Este método se llama cuando un objeto entra en el área del Trigger del Shifter
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobamos si el objeto tiene el tag "Alien"
        if (other.CompareTag("Alien"))
        {
            // Imprimir en consola para ver si se detecta el alien correctamente
            Debug.Log("Alien detectado: " + other.gameObject.name);

            if (!activado)
            {
                ActivarShifter();
            }
        }
    }

    // Método para activar el Shifter
    void ActivarShifter()
    {
        activado = true;  // Marca el Shifter como activado

        // Desactivar el Collider del bloque
        if (bloqueCollider != null)
        {
            bloqueCollider.enabled = false;
        }
    }
}
