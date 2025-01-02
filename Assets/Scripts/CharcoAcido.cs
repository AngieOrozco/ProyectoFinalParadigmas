using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra en el charco es el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador tocó el ácido. ¡Game Over!");

            // Aquí puedes restar vidas, reiniciar el nivel, etc.
            // Ejemplo: Destruir al jugador
            Destroy(collision.gameObject);

            // Si quieres reiniciar el nivel:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

