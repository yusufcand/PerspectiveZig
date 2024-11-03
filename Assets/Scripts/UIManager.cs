using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highscore1;
    public Text highscore2;
    
    public static UIManager UIinstance;
    void Start()
    {
        highscore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    private void Awake()
    {
        if (UIinstance == null)
        {
            UIinstance = this;   
        }
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().Play("GameOverPanel");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
