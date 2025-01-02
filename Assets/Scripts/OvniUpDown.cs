using UnityEngine;

public class MovimientoArribaAbajo : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad del movimiento
    public float altura = 1f;   // Distancia de movimiento arriba y abajo

    private Vector3 posicionInicial;

    void Start()
    {
        // Guardamos la posición inicial del OVNI
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posición en el eje Y usando una función seno
        float nuevaPosicionY = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + nuevaPosicionY, posicionInicial.z);
    }
}
