using System.Collections.Generic;
using UnityEngine;

public class FirstPersonHoops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hoops;
    public GameObject MotionHoops;
    public float probVert = 10, probHori = 30, probStat = 60;
    public Transform ARCamera;
    // the radius
    private float radius;
    public static int HoopsNumber = 0;
    void Start()
    {
        HoopsNumber = 0;
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

        int factor = Random.Range(-4, 4);
        HoopsNumber++;
        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(-70, factor * (rangey / 10), 0));
        //MotionHoops.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
    }
    void InstantiateHorizontalHoops(float rangex) { 
        MotionHoops = Resources.Load<GameObject>("Prefabs/HoopMotionHori");

        int factor = Random.Range(-5, 2);   
        HoopsNumber++;
        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(factor * (rangex / 10), -95, 0));
    }

    void InstantiateStaticHoops(float rangex, float rangey) {
        MotionHoops = Resources.Load<GameObject>("Prefabs/HoopMotion");

        int factorX = Random.Range(-5, 2);   
        int factorY = Random.Range(-4, 4);

        HoopsNumber++;

        Instantiate(MotionHoops, new Vector3(ARCamera.position.x, ARCamera.position.y, ARCamera.position.z), 
                    Quaternion.Euler(factorX * (rangex / 10), factorY * (rangey / 10), 0));
     }

    void SpawnHoops(int score) {
//         float probability = score * score / 8 + 50; // for debugging 
        int random = Random.Range(0, 100);
        if (random > 0 && random <= probVert && DetectCollision.Score > 5) 
            InstantiateVerticalHoops(80);
        else if (random > probVert && random <= probStat && DetectCollision.Score > 5) 
            InstantiateHorizontalHoops(75);
        else if (random > probStat && random <= 100)
            InstantiateStaticHoops(75, 80);

    }

    // Update is called once per frame
    void Update()
    {
        while (HoopsNumber < 5) { 
            SpawnHoops(DetectCollision.Score);
        }
    }
}
