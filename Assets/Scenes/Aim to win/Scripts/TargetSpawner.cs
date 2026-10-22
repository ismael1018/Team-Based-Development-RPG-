using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject dangerousTargetPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 1f;
    [Range(0f, 1f)]
    public float dangerousSpawnChance = 0.25f;
    private float spawnTimer = 0f;

    void Update()
    {
        TargetGameManager manager = FindFirstObjectByType<TargetGameManager>();

        if (manager == null || manager.enabled == false)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnTarget();
            spawnTimer = 0f;
        }
    }

    void SpawnTarget()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            return;
        }

        GameObject prefabToSpawn = targetPrefab;

        if (dangerousTargetPrefab != null && Random.value < dangerousSpawnChance)
        {
            prefabToSpawn = dangerousTargetPrefab;
        }

        if (prefabToSpawn == null) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity
        );
    }
}