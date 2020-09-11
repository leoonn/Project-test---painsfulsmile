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
    public TMP_Text time;
    
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = timeGame.value.ToString();
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        time.text = PlayerPrefs.GetInt("TimeGame", 0).ToString();
    }

    public void CloseOptions()
    {
        PanelOptions.SetActive(false);
        
    }
    public void Options()
    {
        PanelOptions.SetActive(true);
      
    }

}
