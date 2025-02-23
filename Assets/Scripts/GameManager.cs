using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public WallSpawner wallSpawner;
    public AudioClip tempclip;
    private bool cheatMode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        wallSpawner.OnSuccesfullHit += IncreaseScore;

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

    public void IncreaseScore()
    {
        score += 1;
        SoundManager.Instance.playSound(tempclip);
    }
}
