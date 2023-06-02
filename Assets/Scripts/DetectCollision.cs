using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{
    public GameObject ScoreBox;
    public static int ScoreDetected = 0;
    public static int Score = 5;
    public AudioSource AudioSrc;
    public AudioClip AudioClp;
    // Start is called before the first frame update
    void Start()
    {
        AudioSrc = this.gameObject.AddComponent<AudioSource>();
        AudioSrc.clip = Resources.Load<AudioClip>("Sounds/PerfectScore");
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
            AudioSrc.Play();
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
            GameObject obj = Resources.Load<GameObject>("Prefabs/Confetti");
            obj = Instantiate(obj, other.gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<ParticleSystem>().Play();
            Destroy(obj, 1);
            Destroy(other.gameObject.transform.parent.gameObject); 
        }
    }


}

