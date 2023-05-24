using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform TargetObject;  // where the ball should be thrown
    public float LaunchAngle = 45;
    public GameObject button;
    void Start()
    {
        TargetObject = GameObject.Find("Target").transform;
        button = GameObject.Find("Button");
    }

    public void Throw() { 
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.None;

        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 targetXZPos = new Vector3(TargetObject.position.x, 0.0f, TargetObject.position.z);

        transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = TargetObject.position.y - transform.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)) );
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        rigid.velocity = globalVelocity;
        Debug.Log("Throw is called");
    }
    // Update is called once per frame
    void Update()
    {
        button.GetComponent<Button>().onClick.AddListener(Throw);
    }
}
