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
        //Instantiate(TargetSphere, TargetObject.transform.position, Quaternion.identity);


        // set parent to ARCAmera
    }

    void Update() { 
        PlaceTargetObject();
    }

    void PlaceTargetObject() { 
        // if plane 
        // RaycastHit hit;
        // Debug.Log("Target called");
        // if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit)) { 
        //     if (hit.transform.tag == "Environment"){

        //         TargetObject.transform.position = hit.point;
        //         TargetSphere.transform.position = TargetObject.transform.position;
        //         Debug.Log("Target Placed");
        //         Debug.Log(hit.point);
        //     }
        // }

        // if first person
        TargetObject.transform.position = ARCamera.position + ARCamera.forward * radius;
        TargetSphere.transform.position = ARCamera.position + ARCamera.forward * radius;
    }
}
