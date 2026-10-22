using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
       void Update()
    {
        // Move left every frame at a constant speed
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
