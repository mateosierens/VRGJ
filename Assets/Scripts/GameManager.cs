using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public WallSpawner wallSpawner;

    // Start is called before the first frame update
    void Start()
    {
        wallSpawner.OnSuccesfullHit += this.IncreaseScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        score += 1;
    }
}
