using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject.Find("Phone").GetComponent<PhoneManager>().Show = true;
    }
}
