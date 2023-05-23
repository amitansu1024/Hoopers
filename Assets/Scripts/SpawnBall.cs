using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject[] PreFab;

    private Rigidbody rigid;
    private Transform TargetObject;
    private Transform ARCamera;
    private int SpawnNumber = 0;
    private int DestroyNumber;
    [Range(20.0f, 75.0f)] public float LaunchAngle;
    bool isThrowed = false;
    bool ShootReady = true;
    private Vector3 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        PreFab = new GameObject[50];
        TargetObject = GameObject.Find("Target").transform;
        ARCamera = GameObject.Find("AR Camera").transform;
        InitialPosition = new Vector3(ARCamera.position.x - 13.0f, ARCamera.position.y - 10.0f, ARCamera.position.z + 7.0f);

        Spawn(SpawnNumber);
        Throw();
    }

    void Spawn(int i) { 
        PreFab[i] = Resources.Load<GameObject>("Prefabs/BasketBall");

        PreFab[i] = Instantiate(PreFab[i], InitialPosition, Quaternion.identity);

    }
    // Update is called once per frame
    private IEnumerator ThrowCoroutine() { 
        ShootReady = true;
        yield return new WaitForSeconds(2);
    }
    public void Throw()  
    {
        PreFab[SpawnNumber].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        Vector3 projectileXZPos = new Vector3(InitialPosition.x, 0.0f, InitialPosition.z);
        Vector3 targetXZPos = new Vector3(TargetObject.position.x, 0.0f, TargetObject.position.z);

        PreFab[SpawnNumber].transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = TargetObject.position.y - PreFab[SpawnNumber].transform.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)) );
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0, Vy, Vz);
        Vector3 globalVelocity = PreFab[SpawnNumber].transform.TransformDirection(localVelocity);

        PreFab[SpawnNumber].GetComponent<Rigidbody>().velocity = globalVelocity;
        Debug.Log("Throw is called");
        isThrowed = true;
        SpawnNumber++;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && ShootReady == true) { 
            Throw();
            ShootReady = false;
        }

        if (isThrowed) { 
            StartCoroutine(ThrowCoroutine());
            Spawn(SpawnNumber);
            isThrowed = false;
        }
    }
}