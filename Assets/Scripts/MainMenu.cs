using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Quitgame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}