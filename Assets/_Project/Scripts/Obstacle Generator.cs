using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your cube prefab in the inspector
    public float tubeRadius = 10f;
    public float minOffset = 7f;
    public float maxOffset = 10f;
    public float distanceBetweenCubes = 3f;
    public float pipeLength = 100f; // Set this to the length of your pipe

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for (float i = 0; i < pipeLength; i += distanceBetweenCubes)
        {
            Vector3 cubePosition = GetRandomPosition(i);
            // Convert local position to world position
            Vector3 worldPosition = transform.TransformPoint(cubePosition);
            // Instantiate the cube at the generated world position
            Instantiate(cubePrefab, worldPosition, Quaternion.identity, transform);
        }
    }

    Vector3 GetRandomPosition(float yPosition)
    {
        float angle = Random.Range(0, 2 * Mathf.PI); // Random angle in radians
        float radius = Random.Range(minOffset, maxOffset); // Random radius within specified range

        // Calculate x and y using polar coordinates
        float x = radius * Mathf.Cos(angle);
        float z = radius * Mathf.Sin(angle);

        // Return the 3D position of the cube
        return new Vector3(x, yPosition, z);
    }
}
