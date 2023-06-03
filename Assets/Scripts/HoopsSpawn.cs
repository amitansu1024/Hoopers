using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HoopsSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hoops;
    public Transform ARCamera;
    void Start()
    {
        Hoops = Resources.Load<GameObject>("Prefabs/Hoop");
        ARCamera = GameObject.Find("AR Camera").transform;
        Vector3 Position = new Vector3(ARCamera.position.x + 10.0f, ARCamera.position.y - 10.0f, ARCamera.position.z + 7.0f);
        Instantiate(Hoops, Position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
