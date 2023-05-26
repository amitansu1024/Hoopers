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
    }
    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.name == "ScoreHitbox") { 
            Debug.Log("SCored ball touched with net");
            ScoreBox.GetComponent<TextMeshProUGUI>().text = "Score : "  + ++Score;
            Destroy(other.gameObject.transform.parent.gameObject);
            FirstPersonHoops.HoopsNumber--;
            ScoreDetected++;
        }
    }


}

