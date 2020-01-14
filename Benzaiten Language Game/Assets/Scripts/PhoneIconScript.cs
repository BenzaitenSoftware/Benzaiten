using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneIconScript : MonoBehaviour
{
    [SerializeField]
    private string appName;

    private void OnMouseDown()
    {
        if (appName == "Phrasebook")
        {
            SceneManager.LoadScene("Phrasebook");
        }
        else
        {
            GetComponentInParent<PhoneManager>().IconClick(appName);
        }
    }
}
