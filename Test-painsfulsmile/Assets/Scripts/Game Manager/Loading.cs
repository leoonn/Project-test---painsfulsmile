using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScreen;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadActive()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadingTutorial());
    }
    IEnumerator LoadingTutorial()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameScene");
    }
    public void SkipButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
