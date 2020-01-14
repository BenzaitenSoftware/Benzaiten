using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    private DataHolder dataHolder;
    [SerializeField]
    private string MethodName;
    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();    
    }

    private void OnMouseDown()
    {
        if (MethodName == "Exit")
        {
            dataHolder.Exit();
        }
        else if (MethodName == "Reset")
        {
            dataHolder.ResetPlayer();
        }
    }
}
