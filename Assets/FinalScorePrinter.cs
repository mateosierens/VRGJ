using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScorePrinter : MonoBehaviour
{

    
    public TMP_Text gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.text = "GAME OVER\n Your Score: " + ScoreKeeper.Instance.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
