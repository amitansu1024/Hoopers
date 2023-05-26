using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAndThrow : MonoBehaviour
{
    public GameObject PreFab;

    private Transform TargetObject;
    private Transform ARCamera;
    public static int SpawnNumber = 0;
    private int DestroyNumber;
    [Range(45.0f, 75.0f)] public float LaunchAngle;
    bool isThrowed = false;
    bool ShootReady = true;
    private Vector3 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        LaunchAngle = 75;
        TargetObject = GameObject.Find("Target").transform;
        ARCamera = GameObject.Find("AR Camera").transform;
        InitialPosition = new Vector3(ARCamera.position.x, ARCamera.position.y - 1.0f, ARCamera.position.z + 2.0f);

//        Throw();
    }

    void Spawn() { 
        PreFab = Resources.Load<GameObject>("Prefabs/BasketBall");

        PreFab = Instantiate(PreFab, InitialPosition, Quaternion.identity);
        PreFab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    // Update is called once per frame
    private IEnumerator ThrowCoroutine() { 
        ShootReady = true;
        yield return new WaitForSeconds(2);
    }
    public void Throw()  
    {
        Spawn();


        Vector3 projectileXZPos = new Vector3(InitialPosition.x, 0.0f, InitialPosition.z);
        Vector3 targetXZPos = new Vector3(TargetObject.position.x, 0.0f, TargetObject.position.z);

        Debug.Log(targetXZPos);
        PreFab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        PreFab.transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = TargetObject.position.y - PreFab.transform.position.y;
        Debug.Log(H);
        Debug.Log(R);
        Debug.Log(G);

        Debug.Log(tanAlpha);
        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(Mathf.Abs(G * R * R / (2.0f * (H - R * tanAlpha))) );
        float VzDebug = -(G * R * R / (2.0f * (H - R * tanAlpha)) );
        Debug.Log(Vz);
        Debug.Log(VzDebug);
        float Vy = tanAlpha * Vz;
        Debug.Log(Vy);

        Vector3 localVelocity = new Vector3(0, Vy, Vz);
        Debug.Log(localVelocity);
        Vector3 globalVelocity = PreFab.transform.TransformDirection(localVelocity);

        Debug.Log(globalVelocity);
        PreFab.GetComponent<Rigidbody>().velocity = globalVelocity;
        Debug.Log("Throw is called");
        SpawnNumber++;
        isThrowed = true;

    }
    void PerfectScore() { 
        if (DetectCollision.ScoreDetected != SpawnNumber) {
            DetectCollision.Score += DetectCollision.Score  * DetectCollision.ScoreDetected;
            DetectCollision.ScoreDetected = 0; 
            SpawnNumber = 0;
        } else {
            Debug.Log("Perfect Score" + DetectCollision.ScoreDetected);
        }
    }
    void Update()
    {
        PerfectScore();
        Destroy(PreFab, 5);
    }
}
