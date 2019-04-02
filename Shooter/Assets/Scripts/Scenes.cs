using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Scores()
    {
        SceneManager.LoadScene("Scores");
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
