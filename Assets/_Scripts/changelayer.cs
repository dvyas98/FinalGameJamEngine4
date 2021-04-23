using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class changelayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPower(InputValue button)
    {

        Debug.Log("specialPower");
        gameObject.layer = LayerMask.NameToLayer("WallLayer");
    }
}
