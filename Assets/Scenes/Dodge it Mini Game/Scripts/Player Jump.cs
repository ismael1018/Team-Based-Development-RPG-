using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;   // how strong the jump is
    private bool isGrounded = true; // tracks if player is currently on the ground
    private Rigidbody2D rb;

    void Awake()
    {
        // Get the Rigidbody2D component 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If space bar is pressed AND player is on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // apply upward force
            isGrounded = false; // player is now in the air
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if it's on ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}