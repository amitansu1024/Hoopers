using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ARCamera;
    public GameObject TargetObject;
    public static float radius = 18.0f;
    public GameObject TargetSphere;
    void Start()
    {
        ARCamera = GameObject.Find("AR Camera").transform;
        TargetObject = GameObject.Find("Target");
        TargetSphere = GameObject.Find("TargetSphere");
    }

    void Update() { 
        PlaceTargetObject();
    }

    void PlaceTargetObject() { 
        // target movement
        TargetObject.transform.position = ARCamera.position + ARCamera.forward * radius;
        TargetSphere.transform.position = ARCamera.position + ARCamera.forward * radius;
    }
}
