using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI Text;

    private float currrentTime = 0;
    private float startingTime = 60;
    void Start()
    {
        currrentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currrentTime -= 1 * Time.deltaTime;
        Text.text = currrentTime.ToString("0");
        if (currrentTime<=0)
        {
            SceneManager.LoadScene("Lose");
            //Application.LoadLevel("Lose");
        }
    }
}
