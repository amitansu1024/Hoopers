using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlane : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plane;
    private Transform ARCamera;

    private bool PlacePlane = false;

    void Start()
    {
        ARCamera = GameObject.Find("AR Camera").transform;
        Plane = Resources.Load<GameObject>("Prefabs/Plane");


        Vector3 Position = new Vector3(ARCamera.position.x + 3, ARCamera.position.y - 10.0f, ARCamera.position.z + 7.0f);
        if (PlacePlane)
        {
            // create plane by rayCast
        }
        else CreatePlane(Position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreatePlane(Vector3 position) { 
        Instantiate(Plane, position, Quaternion.identity);
    }
}
