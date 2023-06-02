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
        FirstPersonHoops.HoopsNumber--;
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Confetti"), transform.GetChild(0).transform.position,
                                     Quaternion.identity);
        Destroy(obj, 1);
        //Resources.Load<GameObject>("Prefabs/Confetti").GetComponent<ParticleSystem>().Simulate(2, false, false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
