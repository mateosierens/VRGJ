using UnityEngine;

public class MovingWall : MonoBehaviour
{
    // Make sure to assign this prefab in the Inspector.
    // It should be the same prefab that has this script attached.
    public GameObject wallPrefab; 
    public float speed = 2f;
    public float distance = 10f; // Distance to travel before destroying

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        if (wallPrefab == null)
        {
            Debug.LogError("Wall Prefab is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        // Move the wall in one direction (right along the X-axis)
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
        if (wallPrefab != null)
        {
            // Instantiate a new wall at the start position.
            var newWall = Instantiate(wallPrefab, startPosition, Quaternion.identity);
            newWall.name = "Wall";
        }
        else
        {
            Debug.LogError("Cannot spawn new wall because wallPrefab is not assigned.");
        }
    }
}
