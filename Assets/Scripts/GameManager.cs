using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMinstance;
    public bool gameOver;
    void Start()
    {
        gameOver = false;
    }

    private void Awake()
    {
        if (GMinstance == null)
        {
            GMinstance = this;
        }
    }
    void Update()
    {
        
    }

    public void StartGame()
    {
        UIManager.UIinstance.GameStart();
        ScoreManager.SMinstance.StartScore();
        GameObject.Find("Platform Spawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        UIManager.UIinstance.GameOver();
        ScoreManager.SMinstance.StopScore();
        gameOver = true;
    }
}
