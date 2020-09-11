using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuation : MonoBehaviour
{
    public  int points;
    public Text ScoreText;
    //public Text HighScoreText;
    public  int pointsEnemy = 1;
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void GetPontuation()
    {
        points += pointsEnemy;
        ScoreText.text = points.ToString();
    }

    
}
