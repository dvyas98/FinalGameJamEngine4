using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultUI : MonoBehaviour
{
    private TextMeshProUGUI number1;
    private TextMeshProUGUI number2;
    private TextMeshProUGUI number3;
    private TextMeshProUGUI number4;

    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;

    private int num1;
    private int num2;
    private int num3;
    private int num4;

    // Start is called before the first frame update
    void Start()
    {
        num1 = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;

        number1 = Number1.GetComponent<TextMeshProUGUI>();
        number2 = Number2.GetComponent<TextMeshProUGUI>();
        number3 = Number3.GetComponent<TextMeshProUGUI>();
        number4 = Number4.GetComponent<TextMeshProUGUI>();


        number1.text = num1.ToString();
        number2.text = num2.ToString();
        number3.text = num3.ToString();
        number4.text = num4.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
