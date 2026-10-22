using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool canMove = true;
    public MazeGameManager gameManager;
    private Vector2 moveDirection = Vector2.zero;

    void Update()
    {
        if (!canMove) return;

        if (GameFlowManager.Instance != null && !GameFlowManager.Instance.GameplayActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
            moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            moveDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A))
            moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D))
            moveDirection = Vector2.right;
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        if (GameFlowManager.Instance != null &&
            !GameFlowManager.Instance.GameplayActive)
        {
            return;
        }

        transform.position += (Vector3)(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            canMove = false;

            if (gameManager != null)
            gameManager.WinGame();
        }
    }
}