using UnityEngine;

public class Targets : MonoBehaviour
{
    public float launchForce = 8f;
    public bool isDangerous = false;
    private Rigidbody2D rb;
    private bool alreadyHit = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0f, launchForce);
        }
    }

    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            DestroyTarget();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            DestroyTarget();
        }
    }

    void DestroyTarget()
    {
        if (alreadyHit) return;

        alreadyHit = true;

        TargetGameManager manager = FindFirstObjectByType<TargetGameManager>();

        if (manager != null)
        {
            manager.TargetHit(isDangerous);
        }

        Destroy(gameObject);
    }
}