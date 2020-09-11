using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PanelOptions;
    
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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
