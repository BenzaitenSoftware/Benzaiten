using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeController : MonoBehaviour
{
    private Dictionary<int, string> tableSettings;
    private DataHolder dataHolder;
    public GameObject panel;
    public TextMeshProUGUI text;

    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();

        float height = Camera.main.orthographicSize * 2.0f;
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

        transform.localScale = new Vector3(width, width, width);

        tableSettings = new Dictionary<int, string>();
        tableSettings[1] = "Kaoru";
        tableSettings[2] = "Guide";

        string names = "";

        foreach (string name in dataHolder.PlayerProgression.Keys)
        {
            if (dataHolder.PlayerProgression[name] >= 1)
            {
                names += (name + " ");
            }
        }

        if (names != "")
        {
            text.text = "One or more conversations completed! Your friends are now: " + names + ". (Social Media to be Implemented!)";
            panel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            panel.SetActive(false);
        }
    }

    public void TableClick(int tableNumber)
    {
        Debug.Log(tableNumber);

        if (tableSettings.ContainsKey(tableNumber))
        {
            Debug.Log(tableSettings[tableNumber] + "'s Table has been clicked!");
        }
        else
        {
            Debug.Log("Table " + tableNumber + " does not have a person!");
        }

        dataHolder.LoadConversation(tableSettings[tableNumber] + ".json");
    }
}
