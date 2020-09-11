using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    Pontuation pointsScript;
    public GameObject panelGameOver;
    public Text scoreGameOver;
    public Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //get player prefs highscore
        pointsScript = GameObject.Find("GameManager").GetComponent<Pontuation>(); //get componente of other script
    }

    void Update()
    {
        PointsShow(); //call methood of points 
        RecordShow(); //call method of record
    }
    public void PointsShow()
    {
        scoreGameOver.text = pointsScript.points.ToString();  // convert a int in text 
    }

    public void RecordShow()
    {
        if (pointsScript.points > PlayerPrefs.GetInt("HighScore", 0)) //if points > that record its true and record in variable highscore
        {
            PlayerPrefs.SetInt("HighScore", pointsScript.points); // set a highscore 
            highScore.text = pointsScript.points.ToString(); // // convert a int in text 
        }
    }
    public void GameOverActive()
    {
        panelGameOver.SetActive(true); //active a gameobject in unity 
       

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); //load scene rank 
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene"); //load scene rank 
    }
}
