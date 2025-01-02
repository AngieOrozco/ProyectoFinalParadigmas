using UnityEngine;

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");
            // Aquí puedes agregar más lógica, como cargar el siguiente nivel:
            // SceneManager.LoadScene("NombreDelSiguienteNivel");
        }
    }
}