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
    public TextMeshProUGUI text;
    public Image image;
    private DataHolder dataHolder;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
    }

    private void FixedUpdate()
    {
        if (MethodName == "Setup" && image.color.a > 0)
        {
            Color imageColor = image.color;
            Color textColor = text.color;
            imageColor.a -= 0.005f;
            textColor.a -= 0.005f;
            image.color = imageColor;
            text.color = textColor;
        }
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
            Debug.Log(name.Length);
            if (name.Length <= 1)
            {
                text.text = "Please enter a name for your character! (2 or more Characters)";

                Color imageColor = image.color;
                Color textColor = text.color;
                imageColor.a = 1f;
                textColor.a = 1f;
                image.color = imageColor;
                text.color = textColor;
            }
            else if (choice == 0)
            {
                text.text = "Please choose a character!";

                Color imageColor = image.color;
                Color textColor = text.color;
                imageColor.a = 1f;
                textColor.a = 1f;
                image.color = imageColor;
                text.color = textColor;
            }
            else
            {
                dataHolder.SetupPlayer(name, choice);
            }
        }
    }
}
