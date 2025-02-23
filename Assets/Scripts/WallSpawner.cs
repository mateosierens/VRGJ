using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WallSpawner : MonoBehaviour
{
    private enum States
    {
        TUTORIAL,
        MAINSTATE
    }

    public List<GameObject> TutorialPrefabs;

    public event Action OnSuccesfullHit;
    public event Action OnFailedHit; 
    public List<GameObject> wallPrefabs;
    private List<GameObject> spawnedWalls;
    public bool started = false;
    public float spawnTimer = 60f;
    public float spawnCooldown = 60f;
    public float maxTravelDistanceWalls = 30f;
    private States state;
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnedWalls = new List<GameObject>();
        state = States.TUTORIAL;
        if (TutorialPrefabs.Count < 1)
        {
            Debug.LogError("NOT ALL TUTORIALS ARE PRESENT!!!!!");
            throw new MissingMemberException();
        }
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
        GameObject spawnedWall;
        
        if (state == States.TUTORIAL)
        {
            spawnedWall = Instantiate(TutorialPrefabs.First(), transform.position, Quaternion.identity);
        }
        else
        {
            spawnedWall = Instantiate(wallPrefabs[UnityEngine.Random.Range(0, wallPrefabs.Count)], transform.position, Quaternion.identity);
        }

        WallConditions conditions = spawnedWall.GetComponent<WallConditions>();
        conditions.OnWallPassed += onSuccesfullWallClear;
        conditions.onWallFailed += onFailedWallClear;
        conditions.playerPos = playerPos;
        var baseComponent = spawnedWall.GetComponent<WallBase>();
        //baseComponent.onPassedSetLimit += deleteWall;
        baseComponent.maxDistance = maxTravelDistanceWalls;
        spawnedWalls.Add(spawnedWall);
    }

    public void startSpawning()
    {
        started = true;
        spawnWall();
    }

    void onSuccesfullWallClear(GameObject clearedWall)
    {
        OnSuccesfullHit?.Invoke();
        if(state == States.TUTORIAL) CompletedATutorialHandle();
        deleteWall(clearedWall);
    }

    void onFailedWallClear(GameObject failedWall)
    {
        OnFailedHit?.Invoke();
        deleteWall(failedWall);
    }
    
    void CompletedATutorialHandle()
    {
        TutorialPrefabs.RemoveAt(0);
        if (TutorialPrefabs.Count == 0) state = States.MAINSTATE;
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
