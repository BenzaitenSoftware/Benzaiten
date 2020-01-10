using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        print("Streaming Assets Path: " + Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*");
        foreach (FileInfo file in allFiles)
        {
            print(file.FullName);
        }
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
