using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public int Score;
    private int random;
    private float probability;
    private float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        Score = DetectCollision.Score;
        // probability = Score * Score / 8 + 30; will be calculated later
        probability = 50;
        random = Random.Range(1, 100);
        m_speed = Score / 20 + 0.301f;
    }

    // Update is called once per frame
    void Update()
    {
        if (random >= probability) { 
            // transform.rotation = new Quaternion(30, 0, 0, 0);
            transform.Rotate(new Vector3(0, m_speed, 0));
            if  (transform.rotation.eulerAngles.y == 90 || transform.rotation.eulerAngles.y == -90)
                transform.rotation.eulerAngles.Set(transform.rotation.eulerAngles.x, -45, transform.rotation.eulerAngles.z);
            }
        else if (random < probability) { 
            //transform.rotation = new Quaternion(m_speed, 0, 0, 0);
            transform.Rotate(new Vector3(-m_speed, 0, 0));
            if (transform.rotation.eulerAngles.x == 90 || transform.rotation.eulerAngles.x == -90)
                m_speed = -m_speed;
        }
    }
}
