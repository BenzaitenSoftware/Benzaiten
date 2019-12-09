using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeController : MonoBehaviour
{
    private Dictionary<int, string> tableSettings;
    private DataHolder dataHolder;
    public GameObject panel;

    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();

        float height = Camera.main.orthographicSize * 2.0f;
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

        transform.localScale = new Vector3(width, width, width);

        tableSettings = new Dictionary<int, string>();
        tableSettings[1] = "Kaoru";
        tableSettings[2] = "Guide";

        foreach (int progress in dataHolder.PlayerProgression.Values)
        {
            if (progress >= 1)
            {
                panel.SetActive(true);
                break;
            }
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
