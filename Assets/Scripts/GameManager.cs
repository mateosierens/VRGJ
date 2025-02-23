using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public WallSpawner wallSpawner;
    public AudioClip successSound;
    public AudioClip failedSound;
    private bool cheatMode = false;
    public GameObject player;
    public UnityEvent<int> ScoreUpdate;
    public UnityEvent<int> LivesUpdate;
    private int successCounter = 0;
    private int failCounter = 0;
    public float cooldownReducionAmount = 1f;
    public int rampUpTreshHold = 3;

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
        SoundManager.Instance.playBackgroundSound();
    }
    
    public void IncreaseScore()
    {
        score += 1;
        SoundManager.Instance.playSound(successSound);
        ScoreUpdate.Invoke(score);
        DifficultyCalculator(true);
    }

    public void onFailedWall()
    {
        score -= 1;
        SoundManager.Instance.playSound(failedSound);
        ScoreUpdate.Invoke(score);
        DifficultyCalculator(false);
        int calcFailcounter = 3 - failCounter;
        LivesUpdate.Invoke(calcFailcounter);
    }
    
    public void DifficultyCalculator(bool success)
    {
        if (success)
        {
            successCounter++;
            if ((successCounter % rampUpTreshHold == 0) && wallSpawner.spawnCooldown > 1f) wallSpawner.spawnCooldown -= cooldownReducionAmount;
            
        }
        else
        {
            failCounter += 1;
            if (failCounter == 3) SceneManager.LoadScene("GameOver");
        }
        
    }
}
