using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{

   //FIrstPersonHoops Hoops;
    public GameObject ScoreBox;
    public static int Score;
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
            //Destroy(other.gameObject);
        }
    }
}

