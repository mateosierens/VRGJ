using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{

    public static ScoreKeeper Instance;
    public int totalScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
