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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
