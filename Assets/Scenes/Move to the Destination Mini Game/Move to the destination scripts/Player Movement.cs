using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How fast the player is able to move
    public float movementSpeed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        // Player being able to move from left to right 
        float x = Input.GetAxisRaw("Horizontal");

        // Player being able to move up and down
        float y = Input.GetAxisRaw("Vertical");

        // Moves the player
        transform.Translate(new Vector2(x, y) * movementSpeed * Time.deltaTime);
    }
}
