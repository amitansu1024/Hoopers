using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public static int SpawnNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDestroy() { 
        SpawnNumber++;
        if (SpawnNumber > DetectCollision.ScoreDetected) { 
            DetectCollision.ScoreDetected = 0;
        }
        if (SpawnNumber >= 4 && DetectCollision.ScoreDetected == 0) { 
            // go to the gameOVer
            SpawnAndThrow.Lives--;
            SpawnNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
