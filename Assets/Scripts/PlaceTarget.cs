using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ARCamera;
    public GameObject TargetObject;
    private float radius = 10.0f;
    public GameObject TargetSphere;
    void Start()
    {
        ARCamera = GameObject.Find("AR Camera").transform;
        TargetObject = GameObject.Find("Target");
        TargetSphere = GameObject.Find("TargetSphere");
        Instantiate(TargetSphere, TargetObject.transform.position, Quaternion.identity);
        Rigidbody rigid = TargetObject.GetComponent<Rigidbody>();


        // set parent to ARCAmera
        rigid.constraints = RigidbodyConstraints.FreezePositionZ;
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
