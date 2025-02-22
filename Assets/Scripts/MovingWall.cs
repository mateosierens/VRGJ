using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingWall : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 10f; // Distance to travel before destroying

    private Vector3 startPosition;
    private GameObject[] wallPrefabs;

    void Start()
    {
        startPosition = transform.position;

        // Load all prefabs from the "Prefabs/Walls" folder and cast them to GameObject[]
        wallPrefabs = Resources.LoadAll<GameObject>("Prefabs/Walls");

        if (wallPrefabs == null || wallPrefabs.Length == 0)
        {
            Debug.LogError("No wall prefabs found in Resources/Prefabs/Walls.");
        }
    }

    void Update()
    {
        // Move the wall forward along the Z-axis
        transform.position += -Vector3.forward * speed * Time.deltaTime;

        // When the wall has moved the specified distance...
        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            SpawnNewWall();
            Destroy(gameObject);
        }
    }

    void SpawnNewWall()
    {
        if (wallPrefabs != null && wallPrefabs.Length > 0)
        {
            // Select a random prefab
            GameObject selectedPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Length)];

            // Instantiate a new wall at the start position.
            Instantiate(selectedPrefab, startPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Cannot spawn new wall because wallPrefabs array is empty.");
        }
    }
}