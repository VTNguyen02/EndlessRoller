using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    private float offset = 40f;
    private float lastSpawnZ = 40f;

    private float spawnThreshold = 10f; // Distance threshold to delete obstacles behind player
    private List<GameObject> spawnedObstacles = new List<GameObject>(); // List to keep track of spawned obstacles

    void Start()
    {
        lastSpawnZ = transform.position.z;
    }

    public void SpawnObstacle()
    {
        Debug.Log("Obstacle Spawn");
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        float newZ = lastSpawnZ + offset;

        // Instantiate the new obstacle and add it to the list
        GameObject newObstacle = Instantiate(obstacleToSpawn, new Vector3(0, 0, newZ), Quaternion.identity);
        spawnedObstacles.Add(newObstacle);

        lastSpawnZ = newZ;

        // Check for and remove obstacles that are behind the player
        RemoveObstaclesBehindPlayer();
    }

    private void RemoveObstaclesBehindPlayer()
    {
        // Loop through the spawned obstacles and destroy those that are behind the player
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = spawnedObstacles[i];

            if (obstacle.transform.position.z < transform.position.z - spawnThreshold)
            {
                Destroy(obstacle);
                spawnedObstacles.RemoveAt(i); // Remove from the list to avoid memory leaks
            }
        }
    }
}
