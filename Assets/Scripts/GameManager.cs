using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public WallSpawner wallSpawner;
    public AudioClip successSound;
    public AudioClip failedSound;
    private bool cheatMode = false;
    public GameObject player;
    public UnityEvent<int> ScoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        wallSpawner.OnSuccesfullHit += IncreaseScore;
        wallSpawner.OnFailedHit += onFailedWall;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("CHEATS ENABLED");
            cheatMode = true;
        }

        else if (Input.GetKeyDown(KeyCode.Equals) && cheatMode)
        {
            wallSpawner.cheatFirstWall();
        }
    }

    public void OnGameStart()
    {
        wallSpawner.playerPos = player.transform;
        wallSpawner.startSpawning();
    }
    
    public void IncreaseScore()
    {
        score += 1;
        SoundManager.Instance.playSound(successSound);
        ScoreUpdate.Invoke(score);
        DifficultyCalculator();
    }

    public void onFailedWall()
    {
        score -= 1;
        SoundManager.Instance.playSound(failedSound);
        ScoreUpdate.Invoke(score);
    }
    
    public void DifficultyCalculator()
    {
        
    }
}
