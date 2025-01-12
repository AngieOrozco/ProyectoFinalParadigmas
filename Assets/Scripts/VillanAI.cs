using UnityEngine;

public class VillainAI : MonoBehaviour
{
    public GameObject alien1;
    public GameObject alien2;
    public float detectionRange = 10f;
    public float shootingCooldown = 1f;
    public GameObject projectilePrefab;

    private float lastShotTime = 0f;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead) return;

        if (IsAlienInRange())
        {
            if (Time.time - lastShotTime > shootingCooldown)
            {
                ShootAtAlien();
                lastShotTime = Time.time;
            }
        }
    }

    bool IsAlienInRange()
    {
        float distanceToAlien1 = Vector2.Distance(transform.position, alien1.transform.position);
        float distanceToAlien2 = Vector2.Distance(transform.position, alien2.transform.position);

        return distanceToAlien1 <= detectionRange || distanceToAlien2 <= detectionRange;
    }

    void ShootAtAlien()
    {
        Vector2 direction = (alien1.transform.position - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Alien"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetBool("isDead", true);

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
