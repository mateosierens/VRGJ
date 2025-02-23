using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public event Action OnSuccesfullHit;
    public List<GameObject> wallPrefabs;
    private List<GameObject> spawnedWalls;
    public bool started = false;
    public float spawnTimer = 60f;
    public float spawnCooldown = 60f;
    public float maxTravelDistanceWalls = 30f;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnedWalls = new List<GameObject>();
        spawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (started) spawningBehaviour();
    }

    private void spawningBehaviour()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnCooldown;
            spawnWall();

        }
    }
    
    void spawnWall()
    {
        GameObject spawnedWall = Instantiate(wallPrefabs[UnityEngine.Random.Range(0, wallPrefabs.Count)], transform.position, Quaternion.identity);
        spawnedWall.GetComponent<WallConditions>().OnWallPassed += onSuccesfullWallClear;
        var baseComponent = spawnedWall.GetComponent<WallBase>();
        baseComponent.onPassedSetLimit += deleteWall;
        baseComponent.maxDistance = maxTravelDistanceWalls;
        spawnedWalls.Add(spawnedWall);
    }

    void startSpawning()
    {
        started = true;
        spawnWall();
    }

    void onSuccesfullWallClear(GameObject clearedWall)
    {
        OnSuccesfullHit?.Invoke();
        deleteWall(clearedWall);
    }
    
    void deleteWall(GameObject expiredWall)
    {
        spawnedWalls.Remove(expiredWall);
        Destroy(expiredWall);
    }

    public void cheatFirstWall()
    {
        if (spawnedWalls.Count > 0)
        {
            onSuccesfullWallClear(spawnedWalls[0]);
            Debug.Log(spawnedWalls.Count);
        }
    }
}
