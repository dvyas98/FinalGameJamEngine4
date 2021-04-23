using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberUI : MonoBehaviour
{

    bool Won;
    public GameObject finalObject;

    private TextMeshProUGUI number1;
    private TextMeshProUGUI number2;
    private TextMeshProUGUI number3;
    private TextMeshProUGUI number4;

    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;

    private TextMeshProUGUI Rnumber1;
    private TextMeshProUGUI Rnumber2;
    private TextMeshProUGUI Rnumber3;
    private TextMeshProUGUI Rnumber4;

    public GameObject RNumber1;
    public GameObject RNumber2;
    public GameObject RNumber3;
    public GameObject RNumber4;


    private int num1;
    private int num2;
    private int num3;
    private int num4;

    // Start is called before the first frame update
    void Start()
    {
        num1 = Random.Range(0, 9);
        num2 = Random.Range(0, 9);
        num3 = Random.Range(0, 9);
        num4 = Random.Range(0, 9);

        number1 = Number1.GetComponent<TextMeshProUGUI>();
        number2 = Number2.GetComponent<TextMeshProUGUI>();
        number3 = Number3.GetComponent<TextMeshProUGUI>();
        number4 = Number4.GetComponent<TextMeshProUGUI>();


        number1.text = num1.ToString();
        number2.text = num2.ToString();
        number3.text = num3.ToString();
        number4.text = num4.ToString();


        Rnumber1 = RNumber1.GetComponent<TextMeshProUGUI>();
        Rnumber2 = RNumber2.GetComponent<TextMeshProUGUI>();
        Rnumber3 = RNumber3.GetComponent<TextMeshProUGUI>();
        Rnumber4 = RNumber4.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rnumber1.text==number1.text && Rnumber2.text == number2.text && Rnumber3.text == number3.text && Rnumber4.text == number4.text)
        {
            //Debug.Log("YouWin!");
            if (!Won)
            {
                Won = true;
                finalObject.SetActive(true);

               
            }
        }
        else
        {
            

            //Debug.Log("NotYet!");
        }




    }
}
