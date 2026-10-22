using UnityEngine;

public class Hitbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Targets target = other.GetComponent<Targets>();

        if (target != null)
        {
            Destroy(target.gameObject);
        }
    }
}