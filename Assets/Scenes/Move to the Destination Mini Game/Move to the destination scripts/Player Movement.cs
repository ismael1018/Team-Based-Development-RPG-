using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    public bool canMove = true;
    public MazeGameManager gameManager;
    public Vector2 moveDirection = Vector2.zero;

    Rigidbody2D myRB;



    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (!canMove) return;

        if (GameFlowManager.Instance != null && !GameFlowManager.Instance.GameplayActive)
        {
            return;
        }

        Debug.DrawRay(transform.position, moveDirection * 5f, Color.orange);


        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector2.up;
                canMove = false;
                CheckWall();

            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection = Vector2.down;
                canMove = false;
                CheckWall();

            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveDirection = Vector2.left;
                canMove = false;
                CheckWall();

            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = Vector2.right;
                canMove = false;
                CheckWall();

            }
        }


       
    }

    void CheckWall()
    {
        LayerMask wallMask = LayerMask.GetMask("Wall");

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, moveDirection * 10f, 10f,wallMask);

        if (hit2D)
        {
            Debug.Log("test: " + hit2D);

            if (hit2D.transform.gameObject.CompareTag("Wall"))
            {

                Debug.Log("Wall hit");

                canMove = true;
            }
        }
    }


    void FixedUpdate()
    {

        if (GameFlowManager.Instance != null &&
            !GameFlowManager.Instance.GameplayActive)
        {
            return;
        }

        if (!canMove)
        {
            Vector2 playerMove = (Vector3)(moveDirection * moveSpeed * Time.fixedDeltaTime * 100);

            myRB.linearVelocity = playerMove;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Wall"))
        {
            canMove = true;
            
        }
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