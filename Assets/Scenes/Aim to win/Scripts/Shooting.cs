using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject hitboxPrefab;
    public Transform center;
    public float hitboxLifetime = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hitboxPrefab == null || center == null)
            {
                Debug.LogWarning("Hitbox reminder");
                return;
            }

            GameObject hitbox = Instantiate(hitboxPrefab, center.position, Quaternion.identity);
            Destroy(hitbox, hitboxLifetime);
        }
    }
}