using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameovermenu;

    public void EnableGameOverMenu()
    {
        gameovermenu.SetActive(true);
    }

    public void DisableGameOverMenu()
    {
        gameovermenu.SetActive(false);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
        SpawnAndThrow.Lives = 1;
    }

    public void Restartbutton()
    {
        SceneManager.LoadScene("Game");
        SpawnAndThrow.Lives = 1;
    }
}
