using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class DetectCollision : MonoBehaviour
{
    public GameObject ScoreBox;
    public static int ScoreDetected = 0;
    public static int Score = 5;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBox = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.name == "ScoreHitbox") { 
            Debug.Log("SCored ball touched with net");
            ScoreBox.GetComponent<TextMeshProUGUI>().text = "Score : "  + ++Score;

            FirstPersonHoops.HoopsNumber--;
            ScoreDetected++;
            Debug.Log("Current Score is " + ScoreDetected);

            if (Score % 10 == 0) { 
                SpawnAndThrow.Lives++;
            }

            if (DestroyBall.SpawnNumber != ScoreDetected && DestroyBall.SpawnNumber >= 1) { 
            }
            else {
                // Score *= ScoreDetected; 
                DestroyBall.SpawnNumber = 0;
                ScoreDetected = 0;
            }

            Destroy(other.gameObject.transform.parent.gameObject); 
        }
    }

    public int GetScore()
    {
        if (Score==5)
        {
            return 0;
        }
        else
        {
            return Score;
        }
    }
}

