using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameOver : MonoBehaviour
{
    public GameObject gameovermenu;

    public void EnableGameOverMenu()
    {
        gameovermenu.SetActive(true);
    }
}
