
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject obstaclePrefab;

    [Header("Configuración")]
    public float spawnInterval = 2f;
    public float spawnX = 9f;
    public float topY = 0.6f;
    public float bottomY = -0.6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }

        if (GameManager.Instance != null &&
    GameManager.Instance.IsGameOver)
        {
            return;
        }
    }

    void SpawnObstacle()
    {
        // Elegir aleatoriamente arriba o abajo.
        float y = Random.value < 0.5f ? topY : bottomY;
        float randomTime = Random.Range(0.3f, 3f);


        Instantiate(
            obstaclePrefab,
            new Vector3(spawnX, y, 0f),
            Quaternion.identity
        );
        spawnInterval = randomTime;
    }
}
