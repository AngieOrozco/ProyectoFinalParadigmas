using UnityEngine;

public class Shifter : MonoBehaviour
{
    public GameObject bloque;
    private Collider2D bloqueCollider;
    private bool activado = false;

    void Start()
    {
        bloqueCollider = bloque.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien"))
        {
            if (!activado)
            {
                ActivarShifter();
            }
        }
    }

    void ActivarShifter()
    {
        activado = true;

        if (bloqueCollider != null)
        {
            bloqueCollider.enabled = false;
        }
    }
}
