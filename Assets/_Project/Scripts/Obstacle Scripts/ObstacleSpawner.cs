using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject player; // Assign the player GameObject in the Inspector
    public GameObject obstaclePrefab; // Assign your obstacle prefab in the Inspector

    public float spawnFrequency = 3.0f; // Time between spawns in seconds
    public Vector2 rectangleSize = new Vector2(10f, 5f); // Width and Depth of the spawn rectangle
    public float spawnHeight = 10.0f; // Height from which obstacles will fall
    public float offsetDistance = 5.0f; // Distance in front of the player to spawn obstacles

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true) // Infinite loop to keep spawning obstacles
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    private void SpawnObstacle()
    {
        if (player == null) return;

        // Calculate the spawn position
        Vector3 playerPosition = player.transform.position;
        Vector3 spawnPosition = playerPosition + player.transform.forward * offsetDistance;
        spawnPosition += new Vector3(Random.Range(-rectangleSize.x / 2, rectangleSize.x / 2), spawnHeight, Random.Range(-rectangleSize.y / 2, rectangleSize.y / 2));

        // Instantiate the obstacle
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
