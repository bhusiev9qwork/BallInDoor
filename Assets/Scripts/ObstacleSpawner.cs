using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool obstaclePool;
    public int numberOfObstacles = 200; 
    public float minSpawnDistance = 1.0f; 
    public float maxSpawnDistance = 10.0f; 

    private List<GameObject> spawnedObstacles = new();

    void Start() => SpawnObstacles();

    public void SpawnObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            float randomX, randomZ;
            Vector3 spawnPosition;

            do
            {
                randomX = Random.Range(-5f, 5f);
                randomZ = Random.Range(-1f, -13f);
                spawnPosition = transform.position + new Vector3(randomX, 0, randomZ);
                if (overlappingCounter > 100) return;
            }
            while (IsOverlapping(spawnPosition, 1.0f));

            var obstacle = obstaclePool.GetPooledObject();
            var capsule = obstacle.GetComponent<Capsule>();
            if (capsule != null) capsule.SetObjectPool(obstaclePool);

            if (obstacle != null)
            {
                obstacle.transform.SetPositionAndRotation(spawnPosition, transform.rotation);
                obstacle.SetActive(true);
                spawnedObstacles.Add(obstacle);
            }
        }
    }

    int overlappingCounter = 0;

    bool IsOverlapping(Vector3 position, float radius)
    {
        foreach (GameObject obstacle in spawnedObstacles)
        {
            if (obstacle.activeInHierarchy)
            {
                float distance = Vector3.Distance(position, obstacle.transform.position);
                if (distance < radius)
                {
                    overlappingCounter++;
                    return true; 
                }
            }
        }
        return false; 
    }
}
