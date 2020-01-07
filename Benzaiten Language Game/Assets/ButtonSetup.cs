using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public string MethodName;

    void Start()
    {
        if (MethodName == "Play")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("DataHolder").GetComponent<DataHolder>().Play);
        }
        else
        {
            gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("DataHolder").GetComponent<DataHolder>().Exit);
        }
    }
}
