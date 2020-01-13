using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeController : MonoBehaviour
{
    private Dictionary<int, string> tableSettings;
    private DataHolder dataHolder;
    public TextMeshProUGUI text;
    public GameObject birdPanel, kaoruPanel;

    void Start()
    {
        SceneManager.sceneLoaded += ProgressionCheck;

        try
        {
            dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        }
        catch(Exception e)
        {
            Debug.Log(e.StackTrace);
        }

        ProgressionCheck(new Scene(), LoadSceneMode.Single);

        float height = Camera.main.orthographicSize * 2.0f;
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

        transform.localScale = new Vector3(width, width, width);

        tableSettings = new Dictionary<int, string>();
        tableSettings[1] = "Kaoru";
        tableSettings[4] = "Guide";
        tableSettings[5] = "BaristaBird";
    }

    private void Update()
    {
        
    }

    public void TableClick(int tableNumber)
    {
        if (tableSettings.ContainsKey(tableNumber))
        {
            Debug.Log(tableSettings[tableNumber] + "'s Table has been clicked!");
            dataHolder.LoadConversation(tableSettings[tableNumber] + ".json");
        }
        else
        {
            Debug.Log("Table " + tableNumber + " does not have a person!");
        }
    }

    private void ProgressionCheck(Scene scene, LoadSceneMode mode)
    {
        if (dataHolder.player.PlayerProgression.ContainsKey("BaristaBird"))
        {
            if (dataHolder.player.PlayerProgression["BaristaBird"] >= 1)
            {
                birdPanel.SetActive(true);
                kaoruPanel.SetActive(true);
                birdPanel.GetComponent<PanelClickScript>().glow = false;
                kaoruPanel.GetComponent<PanelClickScript>().glow = false;
            }
        }
        else if (dataHolder.player.PlayerProgression.ContainsKey("Kaoru"))
        {
            if (dataHolder.player.PlayerProgression["Kaoru"] >= 1)
            {
                birdPanel.SetActive(true);
                kaoruPanel.SetActive(true);
                birdPanel.GetComponent<PanelClickScript>().glow = true;
                kaoruPanel.GetComponent<PanelClickScript>().glow = false;
            }
        }
        else if (dataHolder.player.PlayerProgression["Guide"] >= 1)
        {
            kaoruPanel.SetActive(true);
            kaoruPanel.GetComponent<PanelClickScript>().glow = true;
        }
    }
}
