using System.Collections.Generic;
using UnityEngine;

public class FirstPersonHoops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hoops;
    public GameObject MotionHoops;
    public Transform ARCamera;
    // the radius
    private float radius;
    public static int HoopsNumber = 0;
    void Start()
    {
        radius = PlaceTarget.radius;
        ARCamera = GameObject.Find("AR Camera").transform; 
        Hoops = Resources.Load<GameObject>("Prefabs/Hoop");
        MotionHoops = Resources.Load<GameObject>("Prefabs/HoopMotion");
    }


    void InstantiateHoops(float rangex, float rangey) { 
        float xCoord = Random.Range(-rangex, +rangex);
        float yCoord = Random.Range(-rangey + 3, +rangey);
        // z coordinate should always be at the same distance from camera
        float zCoord = Mathf.Sqrt(radius * radius - xCoord * xCoord - yCoord * yCoord);
        HoopsNumber++;
        Instantiate(Hoops,
                    new Vector3(ARCamera.position.x + xCoord, ARCamera.position.y + yCoord, ARCamera.position.z + zCoord),
                    new Quaternion(0, 180, 0, 0));

    }

    void InstantiateMotionHoops(float rangex, float rangey) { 
        float xAngle = Random.Range(-rangex, +rangex);
        float yAngle = Random.Range(-rangey, +rangey);
        HoopsNumber++;
        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(xAngle, yAngle, 0));
        //MotionHoops.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
    }

    void SpawnHoops(int score) {
        // float probability = score * score / 8 + 50; // for debugging 
        float probability = 50;
        int random = Random.Range(0, 100);
        if (random >= probability) 
            InstantiateMotionHoops(45, 45);
        else if (random < probability) 
            InstantiateHoops(8, 8);

    }

    // Update is called once per frame
    void Update()
    {
        while (HoopsNumber < 5) { 
            SpawnHoops(DetectCollision.Score);
        }
    }
}
