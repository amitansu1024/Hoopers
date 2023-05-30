using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionHorizontal : MonoBehaviour
{
    public int Score;
    private float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        Score = DetectCollision.Score;
        m_speed = Score / 20 + 0.301f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, m_speed, 0), Space.World);
        Destroy(this.gameObject, 25);
    }
}
