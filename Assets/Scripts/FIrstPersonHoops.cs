using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIrstPersonHoops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hoops;
    // the radius
    private float radius = 10.0f;
    private int score = 100;
    private int HoopsNumber = 0;
    void Start()
    {
        Hoops = Resources.Load<GameObject>("Prefabs/Hoop");
    }

    void InstantiateHoops(float rangex, float rangey) { 
        float xCoord = Random.Range(-rangex, +rangex);
        float yCoord = Random.Range(-rangey, +rangey);
        // z coordinate should always be at the same distance from camera
        float zCoord = Mathf.Sqrt(xCoord * xCoord + yCoord * yCoord);
        Instantiate(Hoops,
                    new Vector3(xCoord, yCoord, zCoord),
                    new Quaternion(0, 180, 0, 0));

        HoopsNumber++;
    }
    // Update is called once per frame
    void Update()
    {
        if (score > 50 && HoopsNumber < 5) {
            InstantiateHoops(10, 10);
        }
    }
}
