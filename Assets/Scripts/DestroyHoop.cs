using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDestroy() { 
        FIrstPersonHoops.HoopsNumber--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
