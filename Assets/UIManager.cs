using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreField;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreField.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScoreUpdate(int score)
    {
        scoreField.text = "Score: " + score.ToString();
    }
    
}
