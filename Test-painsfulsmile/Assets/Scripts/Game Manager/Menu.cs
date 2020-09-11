using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject PanelOptions;
    public Slider timeGame;
    public Slider spawnEnemy;
    public TMP_Text time;
    public TMP_Text spawntimeText;
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = timeGame.value.ToString();
        spawntimeText.text = spawnEnemy.value.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        TimeGameSession();
        TimeSpawnEnemy();
    }

    public void CloseOptions()
    {
        PanelOptions.SetActive(false);
        
    }
    public void Options()
    {
        PanelOptions.SetActive(true);
      
    }

    public void TimeGameSession()
    {
        PlayerPrefs.SetFloat("Time", timeGame.value);
    }
    public void TimeSpawnEnemy()
    {
        PlayerPrefs.SetFloat("TimeSpawn", spawnEnemy.value);
    }

}
