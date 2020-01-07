using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeManager : MonoBehaviour
{
    private string url = "lukejansen.co.uk/benzaiten/time.php";
    private string currentDate;
    private string lastDate;

    private void Start()
    {
        StartCoroutine(GetTimeFromServer());
        lastDate = "12-11-2019";
    }

    IEnumerator GetTimeFromServer()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("user-agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36");

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
                GameObject.Find("DataHolder").GetComponent<DataHolder>().Splash(false, webRequest);
            }
            else
            {
                currentDate = webRequest.downloadHandler.text;
                Debug.Log(currentDate);
                CompareDate();
                GameObject.Find("DataHolder").GetComponent<DataHolder>().Splash(true, webRequest);
            }
        }
    }

    private void CompareDate()
    {
        if (currentDate.Equals(lastDate))
        {
            Debug.Log("Date Matches!");
        }
        else
        {
            Debug.Log("Date does not Match!");
        }
    }
}
