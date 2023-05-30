using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{
    public GameObject ScoreBox;
    private int continuousScore; // consequitive score 
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
        // ScoreCombo.SetActive(false);
    }
    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.name == "ScoreHitbox") { 
            Debug.Log("SCored ball touched with net");
            ScoreBox.GetComponent<TextMeshProUGUI>().text = "Score : "  + ++Score;

            FirstPersonHoops.HoopsNumber--;
            ScoreDetected++;
            Debug.Log("Current Score is " + ScoreDetected);

            if (DestroyBall.SpawnNumber == ScoreDetected && DestroyBall.SpawnNumber >= 1) { 
                // display perfect Score
                // Debug.Log("Perfect Score is " + ScoreDetected);
                // ScoreCombo.transform.SetParent(other.gameObject.transform);
                // ScoreCombo.GetComponentInChildren<TextMeshProUGUI>().transform.SetParent(other.gameObject.transform);
            }
            else {
                // Score *= ScoreDetected; 
                DestroyBall.SpawnNumber = 0;
                ScoreDetected = 0;
            }

            Destroy(other.gameObject.transform.parent.gameObject); 
        }
    }


}

