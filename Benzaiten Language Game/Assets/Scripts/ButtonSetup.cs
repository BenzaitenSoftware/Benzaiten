using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public string MethodName;
    private DataHolder dataHolder;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
    }

    void OnClick()
    {
        if (MethodName == "Play")
        {
            dataHolder.Play();
        }
        else if (MethodName == "Exit")
        {
            dataHolder.Exit();
        }
        else if (MethodName == "Setup")
        {
            int choice = 0;

            if (GameObject.Find("Player1 Panel").GetComponent<PlayerSelector>().selected)
            {
                choice = 1;
            }
            else if (GameObject.Find("Player2 Panel").GetComponent<PlayerSelector>().selected)
            {
                choice = 2;
            }
            else if (GameObject.Find("Player3 Panel").GetComponent<PlayerSelector>().selected)
            {
                choice = 3;
            }

            string name = GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text;
            if (choice == 0 || name == "")
            {
                // WARN USER
            }
            else
            {
                dataHolder.SetupPlayer(name, choice);
            }
        }
    }
}
