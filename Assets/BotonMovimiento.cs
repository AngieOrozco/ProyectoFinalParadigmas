using UnityEngine;

public class BotonConMovimiento : MonoBehaviour
{
    public Vector3 posicionInicial; // Posición inicial del botón
    public Vector3 posicionPresionada; // Posición cuando el botón está presionado
    public float velocidad = 5f; // Velocidad del movimiento
    private bool presionado = false;

    private void Start()
    {
        // Guarda la posición inicial del botón
        posicionInicial = transform.position;
        // Define la posición presionada (puedes ajustarla según necesites)
        posicionPresionada = posicionInicial + new Vector3(0, -0.23f, 0); // Baja 0.2 unidades en Y
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            presionado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            presionado = false;
        }
    }

    private void Update()
    {
        // Mueve el botón hacia la posición presionada o la inicial
        if (presionado)
        {
            transform.position = Vector3.Lerp(transform.position, posicionPresionada, velocidad * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, posicionInicial, velocidad * Time.deltaTime);
        }
    }
}
