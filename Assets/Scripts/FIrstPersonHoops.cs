using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIrstPersonHoops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hoops;
    // the radius
    private float radius = 10.0f;
    void Start()
    {
        Hoops = Resources.Load<GameObject>("Prefabs/Hoop");
        InstantiateHoops();
    }

    void InstantiateHoops() { 
        Vector3 Position = new Vector3(0, 0, radius);
        Instantiate(Hoops, Position, new Quaternion(0, 180, 0, 0));
        //Instantiate(Resources.Load<GameObject>("Prefabs/Basketball"), Position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
