using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 6f;
    private bool hasHitPlayer = false;
    Collider2D myCol;

    private void Start()
    {
        myCol = GetComponent<Collider2D>();   
    }

    void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasHitPlayer)
        {
            hasHitPlayer = true;

            JumpGameManager gameManager = FindFirstObjectByType<JumpGameManager>();

            if (gameManager != null)
            {
                gameManager.PlayerHit();
            }

            //Destroy(gameObject);
        }
    }
}