using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WallCreate : MonoBehaviour
{

    public Vector3 currentRotation;
    public Transform playerTransform;
    public GameObject wall;
    public GameObject player;
    bool set = false;
  
    // Start is called before the first frame update
    void awake()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
    void Start()
    {
        currentRotation.x = transform.rotation.x;
        currentRotation.y = transform.rotation.y;
        currentRotation.z = transform.rotation.z;
        

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnSelect(InputValue button)
    {
        //Debug.Log("yes");
        if (!set)
        {
            transform.Rotate(currentRotation.x, currentRotation.y + 90, currentRotation.z);
        }

    }
    public void OnSet(InputValue button)
    {
        set = true;
        Debug.Log("set");
        Instantiate(wall, playerTransform.position, playerTransform.rotation);
    }

    
}
