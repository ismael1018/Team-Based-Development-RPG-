using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 6f; // how fast the enemy flies toward the player

    void Update()
    {
        // Move left every frame at a constant speed
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    // Called automatically when this object's trigger collider overlaps another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player got hit!"); 
        }
    }
}