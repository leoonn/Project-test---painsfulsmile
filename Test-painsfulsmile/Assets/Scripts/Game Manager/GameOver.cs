using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    Pontuation pointsScript;
    public GameObject panelGameOver;
    public TMP_Text scoreGameOver;
    public TMP_Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); 
        pointsScript = GameObject.Find("GameManager").GetComponent<Pontuation>(); 
    }

    void Update()
    {
        PointsShow();  
        RecordShow(); 
    }
    public void PointsShow()
    {
        scoreGameOver.text = pointsScript.points.ToString();  
    }

    public void RecordShow()
    {
        if (pointsScript.points > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", pointsScript.points); 
            highScore.text = pointsScript.points.ToString(); 
        }
    }
    public void GameOverActive()
    {
        panelGameOver.SetActive(true); 
       

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); 
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene"); 
    }
}
