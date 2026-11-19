using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;  
    private bool isGrounded = true;
    private Rigidbody2D rb;

    public float speed = 8f; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; 
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}