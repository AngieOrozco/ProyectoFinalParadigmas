using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;  

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * speed;  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Alien"))
        {
            AlienController alienController = collision.gameObject.GetComponent<AlienController>();
            if (alienController != null)
            {
                alienController.Die();  
            }

            Destroy(gameObject);
        }
    }
}
