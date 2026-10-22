using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float moveSpeed = 9f;
    public Vector2 minBounds = new Vector2(-10f, -3.3f);
    public Vector2 maxBounds = new Vector2(9f, 6f);

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);

        transform.position = position;
    }
}
