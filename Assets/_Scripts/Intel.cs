using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intel : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            SceneManager.LoadScene("Restart");
        }
    }
}
