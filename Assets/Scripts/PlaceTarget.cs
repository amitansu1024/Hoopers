using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ARCamera;
    public GameObject TargetObject;
    void Start()
    {
        ARCamera = GameObject.Find("AR Camera");
        TargetObject = GameObject.Find("Target");
    }

    void Update() { 
        PlaceTargetObject();
    }

    void PlaceTargetObject() { 
        RaycastHit hit;
        Debug.Log("Target called");
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit)) { 
            if (hit.transform.tag == "Environment"){
                TargetObject.transform.position = hit.point;
                Debug.Log("Target Placed");
                Debug.Log(hit.point);
            }
        }
    }
}
