using UnityEngine;
using TMPro;

public class Weightspawner : MonoBehaviour
{
    public GameObject weightPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public TMP_Text choiceText;
    public float choiceTime = 1f;
    public float spawnInterval = 1.5f;
    private float choiceTimer;
    private float spawnTimer;
    private bool choosingSide = false;
    private bool spawning = true;

    void Start()
    {
        spawnTimer = spawnInterval;

        if (choiceText != null)
        {
            choiceText.text = "";
        }
    }

    void Update()
    {
        if (!spawning || weightPrefab == null || leftSpawnPoint == null || rightSpawnPoint == null)
        {
            return;
        }

        if (!choosingSide)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                choosingSide = true;
                choiceTimer = choiceTime;

                if (choiceText != null)
                {
                    choiceText.text = "Choose a side! Q: Left | E: Right";
                }
            }

            return;
        }

        choiceTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnWeight(leftSpawnPoint);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnWeight(rightSpawnPoint);
        }
        else if (choiceTimer <= 0f)
        {
            Transform randomPoint = Random.value < 0.5f? leftSpawnPoint: rightSpawnPoint;

            SpawnWeight(randomPoint);
        }
    }

    void SpawnWeight(Transform spawnPoint)
    {
        Instantiate(weightPrefab, spawnPoint.position, Quaternion.identity);

        choosingSide = false;
        spawnTimer = spawnInterval;

        if (choiceText != null)
        {
            choiceText.text = "";
        }
    }
}
