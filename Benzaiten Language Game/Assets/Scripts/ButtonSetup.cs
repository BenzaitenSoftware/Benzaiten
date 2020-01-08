using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public string MethodName;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (MethodName == "Play")
        {
            SceneManager.LoadScene("CafeScene");
        }
        else if (MethodName == "Exit")
        {
            Application.Quit();
        }
    }
}
