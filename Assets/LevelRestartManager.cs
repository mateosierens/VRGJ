using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestartManager : MonoBehaviour
{
    public String mainScene;
    public String subScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onRestart()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void onFirstLevel()
    {
        SceneManager.LoadScene(mainScene);
    }
    
    public void onSecondLevel()
    {
        SceneManager.LoadScene(subScene);
    }
}
