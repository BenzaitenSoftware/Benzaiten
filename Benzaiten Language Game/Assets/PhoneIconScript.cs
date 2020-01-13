using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneIconScript : MonoBehaviour
{
    [SerializeField]
    private string appName;

    private void OnMouseDown()
    {
        GetComponentInParent<PhoneManager>().IconClick(appName);
    }
}
