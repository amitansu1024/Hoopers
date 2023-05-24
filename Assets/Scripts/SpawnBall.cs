using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{

    private Transform ARCamera;
    private Vector3 InitialPosition;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        ARCamera = GameObject.Find("AR Camera").transform;
        button = GameObject.Find("Button");
        InitialPosition = new Vector3(ARCamera.position.x, ARCamera.position.y - 1.0f, ARCamera.position.z + 1.0f);
    }

    public void Spawn() { 
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        Instantiate(this, InitialPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        button.GetComponent<Button>().onClick.AddListener(Spawn);
        Destroy(this, 3);
    }
}