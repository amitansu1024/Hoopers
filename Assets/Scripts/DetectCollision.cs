using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollision : MonoBehaviour
{
    public GameObject ScoreBox;
    public static int ScoreDetected = 0;
    public static int Score = 0;
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
            ScoreBox.GetComponent<TextMeshProUGUI>().text = "Score : "  + ++Score;

            FirstPersonHoops.HoopsNumber--;
            ScoreDetected++;
           

            // Play the score audio
            AudioSrc.Play();

            // probability for hoops spawning 
            FirstPersonHoops.updateProbability();

            if (Score % 10 == 0) {
                SpawnAndThrow.Lives++;
            }
            Debug.Log(ScoreDetected);
            Debug.Log("spawn" + ScoreDetected);
            if (DestroyBall.SpawnNumber <= ScoreDetected) { 
                // keep track of combos
            }
            else {
                // if combo breaks reset
                Debug.Log("Combo breaks");
                DestroyBall.SpawnNumber = 1;
                ScoreDetected = 0;
            }
            // play confetti animation
            GameObject obj = Resources.Load<GameObject>("Prefabs/Confetti");
            obj = Instantiate(obj, other.gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<ParticleSystem>().Play();
            Destroy(obj, 1);

            // destroy the hoop
            Destroy(other.gameObject.transform.parent.gameObject); 
        }
    }


}

