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

    void InstantiateVerticalHoops(float rangey) { 
        MotionHoops = Resources.Load<GameObject>("Prefabs/HoopMotionVert");

        int factor = Random.Range(-8, 8);
        HoopsNumber++;
        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(-70, factor * (rangey / 10), 0));
        //MotionHoops.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
    }
    void InstantiateHorizontalHoops(float rangex) { 
        MotionHoops = Resources.Load<GameObject>("Prefabs/HoopMotionHori");

        int factor = Random.Range(-8, 2);   
        HoopsNumber++;
        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(factor * (rangex / 10), -95, 0));
    }

    void SpawnHoops(int score) {
//         float probability = score * score / 8 + 50; // for debugging 
        // float probability = 50;
        // int random = Random.Range(0, 100);
        // if (random >= probability) 
        //     InstantiateHorizontalHoops(75);
        // else if (random < probability) 
        //     InstantiateVerticalHoops(80);

        InstantiateVerticalHoops(100);

    }

    // Update is called once per frame
    void Update()
    {
        while (HoopsNumber < 5) { 
            SpawnHoops(DetectCollision.Score);
        }
    }
}
