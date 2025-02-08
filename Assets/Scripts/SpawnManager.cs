using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public RoadSpawner roadSpawner;
    public ObstacleSpawner obstacleSpawner;

    private void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    public void SpawnTriggerEntered(Collider other)
    {
        if (other.CompareTag("RoadTrigger"))
        {
            Debug.Log("Obstacle Road Entered");
            roadSpawner?.MoveRoad();
        }

        if (other.CompareTag("ObstacleTrigger"))
        {
            Debug.Log("Obstacle Trigger Entered");
            obstacleSpawner?.SpawnObstacle();
        }
    }
}
