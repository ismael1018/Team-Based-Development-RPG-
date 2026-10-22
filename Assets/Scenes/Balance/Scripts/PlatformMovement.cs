using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float rotateSpeed = 60f;
    public float maxTilt = 30f;
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        if (rb == null)
        {
            return;
        }

        if (gameManager != null && gameManager.IsGameEnded())
        {
            return;
        }

        float input = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            input = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input = -1f;
        }

        float currentAngle = Mathf.DeltaAngle(0f, rb.rotation);

        if (currentAngle >= maxTilt && input > 0f)
        {
            input = 0f;
        }

        if (currentAngle <= -maxTilt && input < 0f)
        {
            input = 0f;
        }

        rb.MoveRotation(rb.rotation + input * rotateSpeed * Time.fixedDeltaTime
        );
    }
}
