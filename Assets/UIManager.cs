using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreField;
    public TMP_Text livesField;
    public GameManager manager;
    public int livesLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreField.text = "Score: 0";
        livesField.text = "Lives remaining: 3";
    }

    // Update is called once per frame
    void Update()
    {
        livesField.text = "Lives remaining: " + (3 - manager.failCounter);
    }

    public void OnScoreUpdate(int score)
    {
        scoreField.text = "Score: " + score;
    }

    public void OnLivesUpdate(int fails)
    {
        
        livesField.text = "Lives remaining: ";
    }
    
}
