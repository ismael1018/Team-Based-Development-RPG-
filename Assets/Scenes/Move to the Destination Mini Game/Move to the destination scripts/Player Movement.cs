using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Moves like a grid
    public float gridsize = 1f;
    

    // Update is called once per frame
    void Update()
    {
        Vector2 Movement = Vector2.zero;


        // moves the player up down left or right
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Movement = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Movement = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Movement = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Movement = Vector2.right;
        }
        
        // moves the player
        transform.Translate(Movement *  gridsize);
    }
}
