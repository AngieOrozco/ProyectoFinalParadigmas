using UnityEngine;

public class MovementOvni : MonoBehaviour
{
    public float velocidad = 2f; 
    public float altura = 1f;   

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaPosicionY = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + nuevaPosicionY, posicionInicial.z);
    }
}
